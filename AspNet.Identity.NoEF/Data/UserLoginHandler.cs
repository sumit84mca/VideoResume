using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace AspNet.Identity.NoEF.Data
{
    /// <summary>
    /// Handler for 'AspNetIdentity_UserLogin' table.
    /// </summary>
    internal class UserLoginHandler : BaseHandler
    {
        /// <summary>
        /// Returns the list of User logins by user ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of user login information.</returns>
        public List<UserLoginInfo> GetLoginByUserId(String userId) 
        {
            List<UserLoginInfo> logins = new List<UserLoginInfo>();

            using (DbCommand cmd = db.GetStoredProcCommand("AI_GetUserLogin"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        UserLoginInfo login = new UserLoginInfo(Convert.ToString( reader["LoginProvider"] ), Convert.ToString( reader["ProviderKey"] ));

                        logins.Add(login);
                    }
                }
            }

            return logins;
        }

        /// <summary>
        /// Returns the user ID by user login.
        /// </summary>
        /// <param name="login">User's login detail.</param>
        /// <returns>User ID</returns>
        public String GetUserIdByLogin(UserLoginInfo login)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_GetUserIdByLogin"))
            {
                db.AddInParameter(cmd, "ProviderKey", DbType.String, login.ProviderKey);
                db.AddInParameter(cmd, "LoginProvider", DbType.String, login.LoginProvider);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        return Convert.ToString(reader["UserId"]);
                    }
                }
            }

            return String.Empty;
        }

        /// <summary>
        /// Adds a record to 'AspNetIdentity_UserLogin' table.
        /// </summary>
        /// <param name="login">UserLoginInfo to add.</param>
        /// <param name="userId">User ID</param>
        /// <returns>No of records inserted.</returns>
        public Int32 AddLogin(UserLoginInfo login, String userId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_AddUserLogin"))
            {
                db.AddInParameter(cmd, "ProviderKey", DbType.String, login.ProviderKey);
                db.AddInParameter(cmd, "LoginProvider", DbType.String, login.LoginProvider);

                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Deletes a record from 'AspNetIdentity_UserLogin' table.
        /// </summary>
        /// <param name="login">UserLoginInfo to delete.</param>
        /// <param name="userId">User ID</param>
        /// <returns>No of records deleted.</returns>
        public Int32 RemoveLogin(UserLoginInfo login, String userId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUserLogin"))
            {
                db.AddInParameter(cmd, "ProviderKey", DbType.String, login.ProviderKey);
                db.AddInParameter(cmd, "LoginProvider", DbType.String, login.LoginProvider);

                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Deletes all records from 'AspNetIdentity_UserLogin' table by User ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>No of records deleted.</returns>
        public Int32 RemoveAllLogins(String userId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUserLoginAllByUserId"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                return db.ExecuteNonQuery(cmd);
            }
        }

    }
}
