﻿using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace PriceComparator.Concrete
{
    class BioplusWebTestInfoGetter : WebTestInfoGetter
    {
        public override string CompanyName
        {
            get { return "Bioplus"; }
        }

        protected override decimal GetPrice(HtmlNode testRow)
        {
            var priceText = testRow.ChildNodes[5].InnerText.Trim();
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

        public BioplusWebTestInfoGetter(string url)
        {
            Url = url;
        }
    }
}