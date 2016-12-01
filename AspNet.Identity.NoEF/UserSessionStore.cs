using AspNet.Identity.NoEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
   public class UserSessionStore
    {
        private UserSessionHandler UserSessionHandler = new UserSessionHandler();

        public string CreateLoginTrack(LoginTrack loginTrack)
        {
            if (loginTrack == null)
                throw new ArgumentNullException("LoginTrack can not be null.");
            if(loginTrack.UserID==null)
                throw new ArgumentNullException("LoginTrack.UserID can not be null.");
            if (loginTrack.IPAddress == null)
                throw new ArgumentNullException("LoginTrack.IPAddress can not be null.");
                        

            return UserSessionHandler.CreateLoginTrack(loginTrack);
        }
    }
}
