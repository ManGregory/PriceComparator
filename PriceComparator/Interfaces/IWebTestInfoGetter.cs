using System.Collections.Generic;
using PriceComparator.Concrete;

namespace PriceComparator.Interfaces
{
    public interface IWebTestInfoGetter
    {
        IEnumerable<TestInfo> ProcessTestInfos();        
    }
}
