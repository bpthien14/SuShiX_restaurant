using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class OrderTable
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string StaffID { get; set; }
        public int TableNumber { get; set; }
        public string BranchID { get; set; }
        public string CustomerID { get; set; }
        public string Notes { get; set; }
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public string OrderStatus { get; set; }
    }
}
