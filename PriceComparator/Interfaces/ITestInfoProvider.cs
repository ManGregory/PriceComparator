using System.Collections.Generic;
using PriceComparator.Concrete;

namespace PriceComparator.Interfaces
{
    public interface ITestInfoProvider
    {
        IEnumerable<TestInfo> GetTestInfos();
    }
}
