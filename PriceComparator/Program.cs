using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebTestInfoGetter webTestInfoGetter = new SynevoWebTestInfoGetter(@"http://www.synevo.ua/uk/analizy/gormonalna-panel");
            var testInfos = webTestInfoGetter.ProcessTestInfos();
            foreach (var testInfo in testInfos)
            {
                Console.WriteLine(testInfo.ToString());
            }
            Console.ReadKey();
        }

        private static string GerUrl()
        {
            return @"http://www.synevo.ua/uk/analizy/gormonalna-panel";
        }
    }
}
