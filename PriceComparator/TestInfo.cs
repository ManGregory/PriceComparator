using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparator
{
    class TestInfo
    {
        public string CompanyName { get; set; }

        public string Code { get; set; }        

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal UrgentPrice { get; set; }

        public double Term { get; set; }

        public double UrgentTerm { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Price: {1}, UrgentPrice: {2}, Term: {3}, UrgentTerm: {4}",
                Name, Price, UrgentPrice, Term, UrgentTerm);
        }
    }
}
