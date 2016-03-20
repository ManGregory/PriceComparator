using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    class DilaWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Dila"; }
        }

        protected override WebClient CreateWebClient()
        {
            return new WebClient {Encoding = Encoding.GetEncoding(1251)};
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            decimal price;
            return decimal.TryParse(testRow.ChildNodes[1].ChildNodes[0].InnerText.DigitsOnly(), out price)
                ? price
                : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].ChildNodes[2].InnerText;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return testRow.ChildNodes[0].InnerText;
        }

        protected override string GetUrgentTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[3].ChildNodes[0].ChildNodes[2].InnerText;
        }

        protected override decimal GetUrgentPrice(HtmlNode testRow)
        {
            decimal price;
            return Decimal.TryParse(testRow.ChildNodes[3].ChildNodes[0].ChildNodes[0].InnerText.DigitsOnly(), out price)
                ? price
                : -1;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            var testRows = htmlDoc.DocumentNode.SelectNodes("//tr[count(td)=3]");
            return testRows;
        }

        public DilaWebTestInfoGetter(string url)
        {
            Url = url;
        }
    }
}
