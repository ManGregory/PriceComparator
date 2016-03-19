using System;

namespace PriceComparator.Concrete
{
    class TestInfo
    {
        public string CompanyName { get; set; }

        public string Code { get; set; }        

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal UrgentPrice { get; set; }

        public string Term { get; set; }

        public string UrgentTerm { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Price: {1}, UrgentPrice: {2}, Term: {3}, UrgentTerm: {4}",
                Name, Price, UrgentPrice, Term, UrgentTerm);
        }

        public bool IsEmpty()
        {
            return Price == -1 && UrgentPrice == -1 && 
                Term.Trim() == string.Empty && UrgentTerm.Trim() == string.Empty;
        }
    }
}
