using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    public class SynevoTestInfoProvider : TestInfoProvider
    {
        public SynevoTestInfoProvider(string url) : base(url)
        {
        }

        public override string CompanyName
        {
            get { return "Synevo"; }
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//table[@class='table-sm table-analysis-row tr-th-mob']//tr[count(td)=4]");
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            decimal price;
            return Decimal.TryParse(testRow.ChildNodes[3].ChildNodes[0].InnerText.DigitsOnly(), out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[5].InnerText;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].ChildNodes[1].ChildNodes[0].InnerText;
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText;
        }
    }
}
