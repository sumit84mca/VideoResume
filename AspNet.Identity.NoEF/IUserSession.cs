using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    public interface IUserSession
    {
        string UserID { get; set; }
        string AccountID { get; set; }
        string Name { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
        Audit Audit { get; set; }
    }
}
