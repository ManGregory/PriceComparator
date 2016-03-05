using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparator
{
    class DilaWebTestInfoGetter : IWebTestInfoGetter
    {
        private string _url = "http://dila.ua/pricelist/";

        public string CompanyName
        {
            get { return "Dial"; }
        }

        public IEnumerable<TestInfo> ProcessTestInfos()
        {
            throw new NotImplementedException();
        }
    }
}
