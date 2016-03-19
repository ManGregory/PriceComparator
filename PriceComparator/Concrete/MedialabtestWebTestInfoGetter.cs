using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PriceComparator.Concrete
{
    class MedialabtestWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Medialabtest"; }
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            throw new NotImplementedException();
        }

        protected override string GetTerm(HtmlNode testRow)
        {
            throw new NotImplementedException();
        }

        protected override string GetName(HtmlNode testRow)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<HtmlNode> GetHtmlTestRows(HtmlDocument htmlDoc)
        {
            throw new NotImplementedException();
        }

        public MedialabtestWebTestInfoGetter(string url)
        {
            Url = url;
        }
    }
}
