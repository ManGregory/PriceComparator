using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PriceComparator.Concrete
{
    public class NikolabTestInfoProvider : TestInfoProvider
    {
        public NikolabTestInfoProvider(string url) : base(url)
        {
        }

        public override string CompanyName
        {
            get { return "Nikolab"; }
        }

        protected override string GetCode(HtmlNode testRow)
        {
            return testRow.ChildNodes[1].InnerText;
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            decimal price;
            return Decimal.TryParse(testRow.ChildNodes[3].InnerText, out price) ? price : -1;
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            return testRow.ChildNodes[4].InnerText;
        }

        protected override string GetName(HtmlNode testRow)
        {
            return testRow.ChildNodes[2].InnerText;
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.SelectNodes("//div[@class='entry-content article']//tr[count(td)=4]");
        }
    }
}
