using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    public class BioplusTestInfoProvider : TestInfoProvider
    {
        public BioplusTestInfoProvider(string url) : base(url)
        {
        }

        public override string CompanyName
        {
            get { return "Bioplus"; }
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            var priceText = testRow.ChildNodes[5].InnerText.Trim().DigitsOnly();
            decimal price;
            return Decimal.TryParse(priceText, out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[3].InnerText.Trim();
        }

        protected override string GetName(HtmlNode testRow)
        {
            var nameCount = testRow.ChildNodes[1].ChildNodes.Count;
            return testRow.ChildNodes[1].ChildNodes[nameCount == 1 ? 0 : 1].InnerText.Trim();
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return string.Empty;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//div[@class='item-page']//tr[count(td)=3]");
        }
    }
}
