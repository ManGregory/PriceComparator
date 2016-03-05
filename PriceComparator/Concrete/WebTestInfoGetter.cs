using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PriceComparator.Interfaces;

namespace PriceComparator.Concrete
{
    abstract class WebTestInfoGetter : IWebTestInfoGetter
    {
        public string Url { get; set; }

        public virtual string CompanyName { get; set; }

        protected abstract decimal GetPrice(HtmlNode testRow);

        protected abstract string GetTerm(HtmlNode testRow);

        protected abstract string GetName(HtmlNode testRow);

        protected abstract string GetCode(HtmlNode testRow);

        protected abstract string GetUrgentTerm(HtmlNode testRow);

        protected abstract decimal GetUrgentPrice(HtmlNode testRow);

        protected abstract IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc);

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
            return testRows.Select(CreateTestInfo);
        }

        protected virtual TestInfo CreateTestInfo(HtmlNode testRow)
        {
            return new TestInfo
            {
                CompanyName = CompanyName,
                Code = GetCode(testRow),
                Name = GetName(testRow),
                Term = GetTerm(testRow),
                Price = GetPrice(testRow),
                UrgentPrice = GetUrgentPrice(testRow),
                UrgentTerm = GetUrgentTerm(testRow)
            };
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
