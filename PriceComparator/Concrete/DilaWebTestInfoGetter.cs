using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    public class DilaWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Dila"; }
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
            var testRows = htmlDoc.DocumentNode.SelectNodes("//div[@class='analizes-list-table-line']");
            return testRows;
        }

        public DilaWebTestInfoGetter(string pathToPredefined, string url) : base(pathToPredefined, url)
        {
        }
    }
}
