using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app.Models
{
    public class OnlineSession
    {
        public string SessionID { get; set; }
        public string UserID { get; set; }
        public DateTime SessionStart { get; set; }
        public int SessionDuration { get; set; }
        public string DeviceType { get; set; }
        public string IPAddress { get; set; }
        public string InternalSource { get; set; }
    }
}
