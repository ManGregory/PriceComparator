using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PriceComparator.Interfaces;

namespace PriceComparator.Concrete
{
    public abstract class WebTestInfoGetter : IWebTestInfoGetter
    {        
        public string Url { get; set; }

        public virtual string CompanyName { get; set; }

        protected IEnumerable<TestInfo> PredefinedTestInfos;

        protected abstract decimal GetPrice(HtmlNode testRow);

        protected abstract string GetTerm(HtmlNode testRow);

        protected abstract string GetName(HtmlNode testRow);

        protected virtual string GetCode(HtmlNode testRow)
        {
            return string.Empty;
        }

        protected virtual string GetUrgentTerm(HtmlNode testRow)
        {
            return string.Empty;
        }

        protected virtual decimal GetUrgentPrice(HtmlNode testRow)
        {
            return -1;
        }

        protected abstract IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc);

        protected WebTestInfoGetter(string pathToPredefined, string url)
        {
            Url = url;
            PredefinedTestInfos = PredefinedTestGetter.GetPredefinedTestInfos(pathToPredefined);
        }

        public IEnumerable<TestInfo> ProcessTestInfos()
        {
            var testInfos = new List<TestInfo>();            
            using (var client = CreateWebClient())
            {
                testInfos.AddRange(ProcessTestInfos(GetHtmlTestRows(CreateHtmlDocument(client))));
            }
            return testInfos;
        }

        protected virtual IEnumerable<TestInfo> ProcessTestInfos(IEnumerable<HtmlNode> testRows)
        {
            return testRows.Select(CreateTestInfo).Where(t => t!= null && !t.IsEmpty());
        }

        protected virtual TestInfo CreateTestInfo(HtmlNode testRow)
        {
            var testInfo = new TestInfo
            {
                CompanyName = CompanyName,
                Code = GetCode(testRow),
                Name = GetName(testRow),
                Term = GetTerm(testRow),
                Price = GetPrice(testRow),
                UrgentPrice = GetUrgentPrice(testRow),
                UrgentTerm = GetUrgentTerm(testRow)
            };
            var predefinedTestInfo = PredefinedTestGetter.Find(testInfo, PredefinedTestInfos);
            if (predefinedTestInfo != null)
            {
                MergeTestInfo(testInfo, predefinedTestInfo);
                return testInfo;
            }
            return null;
        }

        protected void MergeTestInfo(TestInfo testInfo, TestInfo predefinedTestInfo)
        {
            testInfo.InnerCode = predefinedTestInfo.InnerCode;
            testInfo.Category = predefinedTestInfo.Category;
            testInfo.SubCategory = predefinedTestInfo.SubCategory;
        }

        protected virtual HtmlDocument CreateHtmlDocument(WebClient client)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(new StringReader(client.DownloadString(Url)));
            return htmlDoc;
        }

        protected virtual WebClient CreateWebClient()
        {
            return new WebClient { Encoding = Encoding.UTF8 };
        }
    }
}