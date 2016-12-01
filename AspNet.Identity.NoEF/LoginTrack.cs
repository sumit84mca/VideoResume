using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    public class LoginTrack
    {
        public string Id { get; set; }
        public string  IPAddress { get; set; }
        public string  MACAddress { get; set; }
        public string  Latt { get; set; }
        public string Longg { get; set; }
        public string  Location { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string UserID { get; set; }

    }
}
