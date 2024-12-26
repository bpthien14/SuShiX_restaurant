using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class Staff
    {
        public string StaffID { get; set; }
        public string DepartmentID { get; set; }
        public string BranchID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserID { get; set; }
    }
}
