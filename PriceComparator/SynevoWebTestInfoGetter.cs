using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace PriceComparator
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
            var priceText = GetToBuyNodeAttribute(testRow, "price");
            decimal price;
            return Decimal.TryParse(priceText, out price) ? price : -1;
        }

        protected override double GetTerm(HtmlNode testRow)
        {
            double term;
            return Double.TryParse(testRow.ChildNodes[7].InnerText, out term) ? term : -1;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return GetToBuyNodeAttribute(testRow, "test-name");
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return GetToBuyNodeAttribute(testRow, "code");
        }

        protected override double GetUrgentTerm(HtmlNode testRow)
        {
            return -1;
        }

        protected override decimal GetUrgentPrice(HtmlNode testRow)
        {
            return -1;
        }
    }
}
