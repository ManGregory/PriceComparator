using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PriceComparator.Concrete;
using PriceComparator.Interfaces;

namespace PriceComparator
{
    class Program
    {
        static void Main(string[] args)
        {            
            IEnumerable<IWebTestInfoGetter> webTestInfoGetters = CreateWebTestInfoGetters();
            foreach (var webGetter in webTestInfoGetters)
            {
                var testInfos = webGetter.ProcessTestInfos().ToList();
                //foreach (var testInfo in testInfos)
                //{
                //    Console.WriteLine(testInfo.ToString());
                //}
                File.WriteAllLines(string.Format("parse/{0}.txt", webGetter.GetType()), testInfos.Select(t => t.ToString()));
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static IEnumerable<IWebTestInfoGetter> CreateWebTestInfoGetters()
        {
            return new IWebTestInfoGetter []
            {
                new SynevoWebTestInfoGetter("http://www.synevo.ua/uk/analizy/vse-analizy"),
                new DilaWebTestInfoGetter("http://dila.ua/pricelist/"),
                new DnklabWebTestInfoGetter("http://dnk-lab.com.ua/price.php"),
                new BioplusWebTestInfoGetter("http://www.bioplus.com.ua/pricelist.html"),
                new NikolabWebTestInfoGetter("http://nikolab.com.ua/price/"),
                //new UldcWebTestInfoGetter("http://uldc.com.ua/ru/analizy-i-tseny/itemlist/category/500000007-laboratornye-yssledovanyya.html"),
                //new MedialabtestWebTestInfoGetter("http://medlabtest.ua/patients/analizy_i_zeny/po_nazvaniyu/")
            };
        }
    }
}
