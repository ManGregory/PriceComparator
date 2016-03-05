using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace PriceComparator.Concrete
{
    class SynevoWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Synevo"; }
        }

        private string GetToBuyNodeAttribute(HtmlNode testRow, string attributeName)
        {
            return testRow.ChildNodes[9].ChildNodes[1].Attributes[attributeName].Value;
        }

        public SynevoWebTestInfoGetter(string url)
        {
            Url = url;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//tr[@class='trow']");
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            decimal price;
            return Decimal.TryParse(GetToBuyNodeAttribute(testRow, "price"), out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[7].InnerText;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return GetToBuyNodeAttribute(testRow, "test-name");
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return GetToBuyNodeAttribute(testRow, "code");
        }

        protected override string GetUrgentTerm(HtmlNode testRow)
        {
            return string.Empty;
        }

        protected override decimal GetUrgentPrice(HtmlNode testRow)
        {
            return -1;
        }
    }
}
