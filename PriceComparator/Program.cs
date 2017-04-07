using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PriceComparator.Concrete;
using PriceComparator.Interfaces;

namespace PriceComparator
{
    class Program
    {
        static void Main(string[] args)
        {            
            /*IEnumerable<ITestInfoProvider> webTestInfoGetters = CreateWebTestInfoGetters();
            var webTestInfos = new Dictionary<string, List<TestInfo>>();
            Parallel.ForEach(webTestInfoGetters, (webGetter) =>
            {
                var testInfos = webGetter.GetTestInfos().ToList();
                webTestInfos.Add(((TestInfoProvider)webGetter).CompanyName, testInfos);
                //foreach (var testInfo in testInfos)
                //{
                //    Console.WriteLine(testInfo.ToString());
                //}
                File.WriteAllLines(string.Format("parse/{0}.txt", webGetter.GetType()), testInfos.Select(t => t.ToString()));
            });

            var sameTestInfos = FindSameTestInfos(webTestInfos);

            Console.WriteLine("Press any key...");
            Console.ReadKey();*/
        }

        private static List<Tuple<string, List<TestInfo>>> FindSameTestInfos(Dictionary<string, List<TestInfo>> webTestInfos)
        {
            foreach (var testInfos1 in webTestInfos)
            {
                var existInAll = true;
                foreach (var testInfos2 in webTestInfos)
                {
                    if (testInfos1.Key != testInfos2.Key)
                    {
                        
                    }
                }
            }
            return null;
        }
    }
}
