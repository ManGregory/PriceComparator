using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PriceComparator.Concrete;
using PriceComparator.Interfaces;

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
            IEnumerable<IWebTestInfoGetter> webTestInfoGetters = CreateWebTestInfoGetters();
            var webTestInfos = new Dictionary<string, List<TestInfo>>();
            Parallel.ForEach(webTestInfoGetters, (webGetter) =>
            {
                var testInfos = webGetter.ProcessTestInfos().ToList();
                webTestInfos.Add(((WebTestInfoGetter)webGetter).CompanyName, testInfos);
            });
            return webTestInfos;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var testInfos = GetTestInfos();
            ViewBag["labNames"] = testInfos.Keys;
            ViewBag["categories"] = GetCategories(testInfos);
            ViewBag["subCategories"] = GetSubCategories(testInfos);
            return View(testInfos);
        }

        private List<string> GetSubCategories(Dictionary<string, List<TestInfo>> testInfos)
        {
            throw new NotImplementedException();
        }

        private List<string> GetCategories(Dictionary<string, List<TestInfo>> testInfos)
        {
            throw new NotImplementedException();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}