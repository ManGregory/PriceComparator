using System;
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
            IWebTestInfoGetter webTestInfoGetter = CreateWebTestInfoGetter();
            var testInfos = webTestInfoGetter.ProcessTestInfos();
            foreach (var testInfo in testInfos)
            {
                Console.WriteLine(testInfo.ToString());
            }
            File.WriteAllLines("1.txt", testInfos.Select(t => t.ToString()));
            Console.ReadKey();
        }

        private static IWebTestInfoGetter CreateWebTestInfoGetter()
        {
            //return new SynevoWebTestInfoGetter("http://www.synevo.ua/ru/analizy/zagalnoklinichni-doslidgennia");
            //return new DilaWebTestInfoGetter("http://dila.ua/pricelist/");
            return new DnklabWebTestInfoGetter("http://dnk-lab.com.ua/price.php");
        }
    }
}
