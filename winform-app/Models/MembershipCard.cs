using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class MembershipCard
    {
        public string CardID { get; set; }
        public string CustomerID { get; set; }
        public string StaffID { get; set; }
        public string CardType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public float AccumulatedPoints { get; set; }
    }
}
