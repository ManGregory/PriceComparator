using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PriceComparator.Concrete;
using PriceComparator.Interfaces;
using WebMain.Models;

namespace WebMain.Controllers
{
    public class HomeController : Controller
    {
        private IEnumerable<IWebTestInfoGetter> CreateWebTestInfoGetters()
        {
            string pathToPredefined = HttpContext.Server.MapPath("~/Content/analysis.txt");            

            return new IWebTestInfoGetter[]
            {
                new SynevoWebTestInfoGetter(pathToPredefined, "http://www.synevo.ua/uk/analizy/vse-analizy"),
                new DilaWebTestInfoGetter(pathToPredefined, "http://dila.ua/ua/pricelist/index.html"),
                new DnklabWebTestInfoGetter(pathToPredefined, "http://dnk-lab.com.ua/price.php"),
                new BioplusWebTestInfoGetter(pathToPredefined, "http://www.bioplus.com.ua/pricelist.html"),
                new NikolabWebTestInfoGetter(pathToPredefined, "http://nikolab.com.ua/price/"),
                new UldcWebTestInfoGetter(pathToPredefined, "http://uldc.com.ua/uk/analizy-ciny/itemlist/category/100000007-laboratorni-doslidzhennya.html"),
                new MedialabtestWebTestInfoGetter(pathToPredefined, "http://medlabtest.ua/ua/patients/analizy_i_zeny/po_nazvaniyu/")
            };
        }

        private Dictionary<string, List<TestInfo>> GetTestInfos()
        {
            var cachedWebTestInfos = HttpContext.Cache["webTestInfos"];
            if (cachedWebTestInfos == null)
            {
                IEnumerable<IWebTestInfoGetter> webTestInfoGetters = CreateWebTestInfoGetters();
                var webTestInfos = new Dictionary<string, List<TestInfo>>();
                Parallel.ForEach(webTestInfoGetters, (webGetter) =>
                {
                    var testInfos = webGetter.ProcessTestInfos().ToList();
                    webTestInfos.Add(((WebTestInfoGetter) webGetter).CompanyName, testInfos);
                });
                cachedWebTestInfos = webTestInfos;
                HttpContext.Cache["webTestInfos"] = cachedWebTestInfos;
            }
            return (Dictionary<string, List<TestInfo>>)cachedWebTestInfos;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string labs,
            string categories,
            string subCategories,
            string tests,
            string submitButton)
        {
            var testInfos = GetTestInfos();
            return View(new PriceViewModel
            {
                TestInfosDictionary = testInfos,
                Labs = new SelectList(testInfos.Keys.Select(l => new SelectListItem { Value = l, Text = l }), "Value", "Text"),
                Categories = GetCategories(testInfos),
                SubCategories = GetSubCategories(testInfos),
                Tests = GetTests(testInfos),
                FilteredTests = GetFilteredTests(testInfos, labs, categories, subCategories, tests)
            });
        }

        private List<TestInfo> GetFilteredTests(Dictionary<string, List<TestInfo>> testInfos, 
            string labName = null,
            string category = null,
            string subCategory = null,
            string test = null)
        {
            var filteredTests = new List<TestInfo>();
            foreach (var tests in testInfos.Values)
            {
                filteredTests.AddRange(tests);
            }
            if (!string.IsNullOrWhiteSpace(labName))
            {
                filteredTests = filteredTests.Where(t => t.CompanyName.ToLower() == labName.ToLower()).ToList();
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                filteredTests = filteredTests.Where(t => t.Category.ToLower() == category.ToLower()).ToList();
            }
            if (!string.IsNullOrWhiteSpace(subCategory))
            {
                filteredTests = filteredTests.Where(t => t.SubCategory.ToLower() == subCategory.ToLower()).ToList();
            }
            if (!string.IsNullOrWhiteSpace(test))
            {
                filteredTests = filteredTests.Where(t => t.InnerCode.ToLower() == test.ToLower()).ToList();
            }
            return filteredTests;
        }

        private SelectList GetTests(Dictionary<string, List<TestInfo>> testInfos)
        {
            var testsList = new List<Tuple<string, string>>();
            foreach (var tests in testInfos)
            {
                testsList.AddRange(tests.Value.Where(t => t.CompanyName.ToLower() == "synevo").Select(t => new Tuple<string, string>(t.InnerCode, t.Name)).Distinct());
            }
            testsList = testsList.Distinct().ToList();
            return new SelectList(testsList.ConvertAll(t => new SelectListItem { Value = t.Item1, Text = t.Item2 }), "Value", "Text");
        }

        private SelectList GetSubCategories(Dictionary<string, List<TestInfo>> testInfos)
        {
            var subCategories = new List<string>();
            foreach (var tests in testInfos)
            {
                subCategories.AddRange(tests.Value.Select(t => t.SubCategory).Distinct());
            }
            subCategories = subCategories.Distinct().ToList();
            return new SelectList(subCategories.ConvertAll(t => new SelectListItem { Value = t, Text = t }), "Value", "Text");
        }

        private SelectList GetCategories(Dictionary<string, List<TestInfo>> testInfos)
        {
            var categories = new List<string>();
            foreach (var tests in testInfos)
            {
                categories.AddRange(tests.Value.Select(t => t.Category).Distinct());
            }
            categories = categories.Distinct().ToList();
            return new SelectList(categories.ConvertAll(t => new SelectListItem {Value = t, Text = t}), "Value", "Text");
        }

        public ActionResult Contact()
        {
            return View(new SearchLabViewModel
            {
                Streets = GetStreets()
            });
        }

        private SelectList GetStreets()
        {
            var pathToStreets = HttpContext.Server.MapPath("~/Content/streets.txt");
            var cachedStreets = HttpContext.Cache["cachedStreets"];
            if (cachedStreets == null)
            {
                var streets = System.IO.File.ReadLines(pathToStreets, Encoding.GetEncoding(1251));
                HttpContext.Cache["cachedStreets"] =
                    new SelectList(streets.Select(s => new SelectListItem {Value = s.Trim(), Text = s.Trim()}), "Value", "Text");
            }
            return (SelectList) HttpContext.Cache["cachedStreets"];
        }

        public ActionResult GetPanelRelations()
        {
            var testInfos = GetTestInfos();
            var categories = GetCategories(testInfos);
            var subCategories = GetSubCategories(testInfos);
            var tests = GetTests(testInfos);
            return Json(new { }, 
                JsonRequestBehavior.AllowGet);
        }
    }
}