using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparator.Concrete
{
    public static class PredefinedTestGetter
    {
        private const char AttributeSeparator = ';';
        private const int AttributesCount = 5;

        public static IEnumerable<TestInfo> GetPredefinedTestInfos(string path)
        {
            var lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding(1251));
            return lines.Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => CreatePredefinedTestInfo(l.Trim())).ToList();
        }

        public static TestInfo Find(TestInfo testInfo, IEnumerable<TestInfo> predefinedTestInfos)
        {
            return
                predefinedTestInfos.FirstOrDefault(
                    p => !testInfo.IsEmpty() && p.CompanyName.ToLower() == testInfo.CompanyName.ToLower() && p.Name.ToLower() == testInfo.Name.ToLower() );
        }

        private static TestInfo CreatePredefinedTestInfo(string line)
        {
            var lineParts = line.Split(new[] {AttributeSeparator}, StringSplitOptions.RemoveEmptyEntries);
            if (lineParts.Length != AttributesCount)
            {
                throw new Exception(string.Format("Invalid string {0}", line));
            }
            return new TestInfo
            {
                InnerCode = lineParts[0],
                Name = lineParts[1],
                Category = lineParts[2],
                SubCategory = lineParts[3],
                CompanyName = lineParts[4]
            };
        }
    }
}
