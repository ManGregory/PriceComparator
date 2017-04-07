using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceComparator.Concrete
{
    public class PredefinedTestInfoFinder
    {
        private const char AttributeSeparator = ';';
        private const int AttributesCount = 5;

        private readonly Lazy<IEnumerable<TestInfo>> _predefinedTestInfos;

        public string Path { get; set; }

        public IEnumerable<TestInfo> PredefinedTestInfos
        {
            get
            {
                return _predefinedTestInfos.Value;
            }
        }

        private IEnumerable<TestInfo> GetPredefinedTestInfos()
        {
            var lines = System.IO.File.ReadAllLines(Path, Encoding.GetEncoding(1251));
            return lines.Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => CreatePredefinedTestInfo(l.Trim())).ToList();
        }

        private TestInfo CreatePredefinedTestInfo(string line)
        {
            var lineParts = line.Split(new[] { AttributeSeparator }, StringSplitOptions.RemoveEmptyEntries);
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

        public PredefinedTestInfoFinder(string path)
        {
            Path = path;
            _predefinedTestInfos = new Lazy<IEnumerable<TestInfo>>(GetPredefinedTestInfos);
        }

        public TestInfo Find(TestInfo testInfo)
        {
            return
                PredefinedTestInfos.FirstOrDefault(
                    p => !testInfo.IsEmpty() && p.CompanyName.ToLower() == testInfo.CompanyName.ToLower() && p.Name.ToLower() == testInfo.Name.ToLower());
        }
    }
}