using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PriceComparator.Interfaces;

namespace PriceComparator.Concrete
{
    public abstract class TestInfoProvider : ITestInfoProvider
    {        
        public string Url { get; set; }

        public virtual string CompanyName { get; set; }

        public PredefinedTestInfoFinder PredefinedTestInfoFinder { get; set; }

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

        protected TestInfoProvider(string url)
        {
            Url = url;
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
            var predefinedTestInfo = PredefinedTestInfoFinder.Find(testInfo);
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
            try
            {
                var plainHtml = client.DownloadString(Url);
                htmlDoc.Load(new StringReader(plainHtml));
            }
            catch (Exception e)
            {                
            }
            return htmlDoc;
        }

        protected virtual WebClient CreateWebClient()
        {
            return new WebClient { Encoding = Encoding.UTF8 };
        }

        public IEnumerable<TestInfo> GetTestInfos()
        {
            var testInfos = new List<TestInfo>();
            using (var client = CreateWebClient())
            {
                var rows = GetHtmlTestRows(CreateHtmlDocument(client));
                if (rows != null)
                {
                    testInfos.AddRange(ProcessTestInfos(rows));
                }
            }
            return testInfos;
        }
    }
}