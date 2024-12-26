using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class StaffWorkHistory
    {
        public int HistoryID { get; set; }
        public string StaffID { get; set; }
        public string BranchID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
