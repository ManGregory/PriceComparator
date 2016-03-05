using System.Collections.Generic;
using PriceComparator.Concrete;

namespace PriceComparator.Interfaces
{
    interface IWebTestInfoGetter
    {
        IEnumerable<TestInfo> ProcessTestInfos();        
    }
}
