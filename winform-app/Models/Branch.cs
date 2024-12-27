using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class Branch
    {
        public string BranchID { get; set; }
        public int RegionID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string BranchPhoneNumber { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public bool HasCarParking { get; set; }
        public bool HasBikeParking { get; set; }
        public bool DeliveryService { get; set; }
        public string ManagerID { get; set; }
    }
}
