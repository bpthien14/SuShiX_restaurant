using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class Users
    {
        public string UserID { get; set; }      // Format: USR00001
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }        // admin, staff, customer

    }
}
