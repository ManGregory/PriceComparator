using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    class SynevoWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Synevo"; }
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
            return Decimal.TryParse(testRow.ChildNodes[5].InnerText.DigitsOnly(), out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[7].InnerText;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return testRow.ChildNodes[3].ChildNodes[1].InnerText;
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].InnerText;
        }
    }
}
