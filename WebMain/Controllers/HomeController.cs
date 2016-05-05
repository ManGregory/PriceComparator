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
                SubCategories = string.IsNullOrWhiteSpace(subCategories) ? new SelectList(new List<SelectListItem>()) : GetSubCategories2(testInfos, categories),
                Tests = string.IsNullOrWhiteSpace(tests) ? new SelectList(new List<SelectListItem>()) : GetTests2(testInfos, categories, subCategories),
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

        private SelectList GetTests2(Dictionary<string, List<TestInfo>> testInfos, string category, string subCategory)
        {
            var testsList = new List<Tuple<string, string>>();
            foreach (var tests in testInfos)
            {
                testsList.AddRange(
                    tests.Value.Where(
                        t => t.CompanyName.ToLower() == "synevo" && t.Category.ToLower() == category.ToLower() &&
                             t.SubCategory.ToLower() == subCategory.ToLower())
                    .Select(t => new Tuple<string, string>(t.InnerCode, t.Name))
                    .Distinct());
            }
            testsList = testsList.Distinct().ToList();
            return new SelectList(testsList.ConvertAll(t => new SelectListItem { Value = t.Item1, Text = t.Item2 }), "Value", "Text");
        }

        private List<Tuple<string, string>> GetTests(Dictionary<string, List<TestInfo>> testInfos, string category, string subCategory)
        {
            var testsList = new List<Tuple<string, string>>(new[] { new Tuple<string, string>(string.Empty, string.Empty) });
            foreach (var tests in testInfos)
            {
                testsList.AddRange(
                    tests.Value.Where(
                        t =>
                            t.CompanyName.ToLower() == "synevo" && t.Category.ToLower() == category.ToLower() &&
                            t.SubCategory.ToLower() == subCategory.ToLower())
                        .Select(t => new Tuple<string, string>(t.InnerCode, t.Name)).Distinct());
            }
            return testsList.Distinct().ToList();
        }

        private SelectList GetSubCategories2(Dictionary<string, List<TestInfo>> testInfos, string category)
        {
            var subCategories = new List<string>();
            foreach (var tests in testInfos)
            {
                subCategories.AddRange(
                    tests.Value.Where(t => t.Category.ToLower() == category.ToLower())
                        .Select(t => t.SubCategory)
                        .Distinct());
            }
            subCategories = subCategories.Distinct().ToList();
            return new SelectList(subCategories.ConvertAll(t => new SelectListItem { Value = t, Text = t }), "Value", "Text");
        }

        private List<Tuple<string, string>> GetSubCategories(Dictionary<string, List<TestInfo>> testInfos, string category)
        {
            var subCategories = new List<Tuple<string, string>>(new[] { new Tuple<string, string>(string.Empty, string.Empty)});
            foreach (var tests in testInfos)
            {
                subCategories.AddRange(
                    tests.Value.Where(t => t.Category.ToLower() == category.ToLower())
                        .Select(t => new Tuple<string, string>(t.SubCategory, t.SubCategory))
                        .Distinct());
            }
            return subCategories.Distinct().ToList();
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

        public ActionResult GetPanelRelations(string category = null, string subCategory = null)
        {
            var testInfos = GetTestInfos();
            var items = new List<Tuple<string,string>>();
            if (!string.IsNullOrWhiteSpace(category))
            {
                items.AddRange(!string.IsNullOrWhiteSpace(subCategory)
                    ? GetTests(testInfos, category, subCategory)
                    : GetSubCategories(testInfos, category));
            }
            return Json(new { Items = items }, 
                JsonRequestBehavior.AllowGet);
        }
    }
}