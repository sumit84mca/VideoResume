using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    public static class IdentityExtensions
    {
        public static Audit getAuditData(this IIdentity _obj, string userid)
        {
            //UserStore userStore = new UserStore();
            //IdentityUser user = userStore.FindByIdAsync(userid).Result;
            //if (user != null)
            //{
            //    return new Audit { AuditAccountId=user.AccountUserId, AuditLoginTrackID= user. };
            //}
            //else
                return null;
        }
    }
}
