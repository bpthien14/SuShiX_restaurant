using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class MenuItem
    {
        public string ItemID { get; set; }
        public string CategoryID { get; set; }
        public string ItemName { get; set; }
        public double CurrentPrice { get; set; }
        public bool DeliveryAvailable { get; set; }
    }
}
