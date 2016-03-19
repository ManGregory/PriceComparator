using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PriceComparator.Utils;

namespace PriceComparator.Concrete
{
    class UldcWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Uldc"; }
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            var priceText = testRow.ChildNodes[11].InnerText.Replace('.', ',');
            decimal price;
            return Decimal.TryParse(priceText, out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return 
                testRow.ChildNodes[9].ChildNodes.Count > 0
                    ? testRow.ChildNodes[9].InnerText
                    : string.Empty;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return
                testRow.ChildNodes[1].ChildNodes.Count > 0
                    ? testRow.ChildNodes[1].InnerText
                    : string.Empty;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//table[@class='uksus']//tr[count(td)=6]");
        }

        public UldcWebTestInfoGetter(string url)
        {
            Url = url;
        }
    }
}
