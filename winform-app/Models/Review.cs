using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class Review
    {
        public string ReviewID { get; set; }
        public string InvoiceID { get; set; }
        public int ServiceScore { get; set; }
        public int LocationScore { get; set; }
        public int FoodQualityScore { get; set; }
        public int PriceScore { get; set; }
        public int AmbianceScore { get; set; }
        public string Comment { get; set; }
    }
}
