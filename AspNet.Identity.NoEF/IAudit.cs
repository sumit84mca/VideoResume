using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    public class Audit
    {
        public string AuditUserId { get; set; }
        public string AuditAccountId { get; set; }
        public string AuditLoginTrackID { get; set; }



        //TODO : find the right place to place this code 
        public static void AddAuditParameters(IApplicationAudit newUser, Database db, DbCommand cmd)
        {
            if (newUser == null) throw new ArgumentNullException("User");
            if (newUser.Audit == null) newUser.Audit = new Audit();


            db.AddInParameter(cmd, "AuditUserId", DbType.String, newUser.Audit.AuditUserId?? default(Guid).ToString());
            db.AddInParameter(cmd, "AuditAccountId", DbType.String, newUser.Audit.AuditAccountId?? default(Guid).ToString());
            db.AddInParameter(cmd, "AuditLoginTrackID", DbType.String, newUser.Audit.AuditLoginTrackID?? default(Guid).ToString());
        }
    }

    public interface IApplicationAudit
    {
        Audit Audit { get; set; }
    }



}
