using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF.Data
{
     internal class UserSessionHandler:BaseHandler
    {

        public string CreateLoginTrack(LoginTrack loginTrack )
        {
            using (DbCommand cmd = db.GetStoredProcCommand("uspLoginCreateLoginTrack"))
            {

                db.AddInParameter(cmd, "Id", DbType.String, loginTrack.Id);
                db.AddInParameter(cmd, "IPAddress", DbType.String, loginTrack.IPAddress);
                db.AddInParameter(cmd, "Latt", DbType.String, loginTrack.Latt);
                db.AddInParameter(cmd, "Location", DbType.String, loginTrack.Location);
                //db.AddInParameter(cmd, "LoginTime", DbType.DateTime, loginTrack.LoginTime==null ? (object)null: loginTrack.LoginTime);
                //db.AddInParameter(cmd, "LogoutTime", DbType.DateTime, loginTrack.LoginTime == null ? (object)null : loginTrack.LoginTime);
                db.AddInParameter(cmd, "Longg", DbType.String, loginTrack.Longg);
                db.AddInParameter(cmd, "MACAddress", DbType.String, loginTrack.MACAddress);
                db.AddInParameter(cmd, "UserID", DbType.String, loginTrack.UserID);

                db.ExecuteNonQuery(cmd);
                return loginTrack.Id;
            }
            
        }

    }
}
