using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PriceComparator.Concrete;

namespace WebMain.Models
{
    public class PriceViewModel
    {
        public Dictionary<string, List<TestInfo>> TestInfosDictionary { get; set; }
        public SelectList Labs { get; set; }
        public SelectList Categories { get; set; }
        public SelectList SubCategories { get; set; }
        public SelectList Tests { get; set; }
        public List<TestInfo> FilteredTests { get; set; }
    }
}