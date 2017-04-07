using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace PriceComparator.Concrete
{
    public class DnklabTestInfoProvider : TestInfoProvider
    {
        public DnklabTestInfoProvider(string url) : base(url)
        {
        }

        public override string CompanyName
        {
            get { return "Dnk"; }
        }

        protected override WebClient CreateWebClient()
        {
            return new WebClient { Encoding = Encoding.GetEncoding(1251) };
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {            
            var priceText = testRow.ChildNodes[2].InnerText.Replace('.', ',');
            decimal price;
            return Decimal.TryParse(priceText, out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return string.Empty;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].InnerText;
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return testRow.ChildNodes[0].InnerText;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//div[@class='content']//tr[count(td)=3]");
        }
    }
}
