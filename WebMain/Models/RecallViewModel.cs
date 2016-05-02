using System.Collections.Generic;
using System.Web.Mvc;

namespace WebMain.Models
{
    public class RecallViewModel
    {
        public SelectList Labs { get; set; }
        public IEnumerable<RecallModel> Recalls { get; set; }
    }
}