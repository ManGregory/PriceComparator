using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    public class MedialabtestWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Medlabtest"; }
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            decimal price;
            return Decimal.TryParse(testRow.ChildNodes[7].InnerText.DigitsOnly(), out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[5].InnerText;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return testRow.ChildNodes[3].InnerText;
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].InnerText;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//div[@class='price-list']//tr[@class='item']");
        }

        public MedialabtestWebTestInfoGetter(string pathToPredefined, string url) : base(pathToPredefined, url)
        {
        }
    }
}
