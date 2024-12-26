using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class MenuItemAvailability
    {
        public string BranchID { get; set; }
        public string ItemID { get; set; }
        public bool IsAvailable { get; set; }
    }
}
