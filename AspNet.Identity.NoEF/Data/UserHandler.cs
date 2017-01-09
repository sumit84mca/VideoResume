using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AspNet.Identity.NoEF.Data
{
    /// <summary>
    /// Handler for 'AspNetIdentity_User' table.
    /// </summary>
    internal class UserHandler : BaseHandler
    {
        /// <summary>
        /// Returns the Identity User object.
        /// </summary>
        /// <param name="reader">IDataReader object with Identity user data.</param>
        /// <returns>Returns IdentityUser.</returns>
        private IdentityUser GetUser(IDataReader reader)
        {
            IdentityUser newUser = null;

            if (reader.Read())
            {

                newUser = new IdentityUser();

                newUser.Id = Convert.ToString(reader["Id"]);
                newUser.UserName = Convert.ToString(reader["LoginId"]);
                newUser.AccountUserId = Convert.ToString(reader["AccountUserId"]);
                newUser.PasswordHash = Convert.ToString(reader["Pwd"]);
                newUser.ApprovalPasswordHash = Convert.ToString(reader["ApprovalPwd"]);
                newUser.SecurityStamp = Convert.ToString(reader["SecurityStamp"]);
                newUser.AccessFailedCount = Convert.ToInt32(reader["AccessFailedCount"]);
                newUser.IsActive = Convert.ToString(reader["IsActive"]);
                newUser.Name = Convert.ToString(reader["Name"]);
                newUser.PhoneNumber = Convert.ToString(reader["Mobile"]);
                newUser.PhoneNumberConfirmed = Convert.ToBoolean(reader["MobileConfirmed"]);
                newUser.Email = Convert.ToString(reader["Email"]);
                newUser.EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]);
                newUser.UserType = Convert.ToString(reader["UserType"]);
            }

            return newUser;
        }
        

        /// <summary>
        /// Returns the User object by user ID.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Returns User.</returns>
        public IdentityUser GetUserById(String userId)
        {
            //using (DbCommand cmd = db.GetStoredProcCommand("AI_GetUser"))
            //{
            //    db.AddInParameter(cmd, "UserId", DbType.String, userId);

            //    return GetUser(db.ExecuteReader(cmd));
            //}

            using (DbCommand cmd = db.GetStoredProcCommand("uspLoginGetUser"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);
                return GetUser(db.ExecuteReader(cmd));
            }
        }
        

        /// <summary>
        /// Returns the User object by user name.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns>Returns User.</returns>
        public IdentityUser GetUserByUserName(String userName)
        {

            //using (DbCommand cmd = db.GetStoredProcCommand("AI_GetUser"))
            //{
            //    db.AddInParameter(cmd, "UserName", DbType.String, userName);

            //    return GetUser(db.ExecuteReader(cmd));
            //}

            using (DbCommand cmd = db.GetStoredProcCommand("uspLoginGetUser"))
            {
                db.AddInParameter(cmd, "UserName", DbType.String, userName);

                return GetUser(db.ExecuteReader(cmd));
            }
        }
        
        /// <summary>
        /// Adds new record to IdentityUser table.
        /// </summary>
        /// <param name="newUser">User to add.</param>
        /// <returns>Returns User.</returns>
        public IdentityUser AddUser(IdentityUser newUser)
        {
            //using (DbCommand cmd = db.GetStoredProcCommand("AI_AddUser"))
            //{
            //    db.AddInParameter(cmd, "UserId", DbType.String, newUser.Id);
            //    db.AddInParameter(cmd, "UserName", DbType.String, newUser.UserName);
            //    db.AddInParameter(cmd, "PasswordHash", DbType.String, newUser.PasswordHash);
            //    db.AddInParameter(cmd, "SecurityStamp", DbType.String, newUser.SecurityStamp);

            //    db.ExecuteNonQuery(cmd);

            //    return GetUserById(newUser.Id);
            //}

            using (DbCommand cmd = db.GetStoredProcCommand("uspLoginCreateUser"))
            {
                db.AddInParameter(cmd, "Id", DbType.String, newUser.Id);
                db.AddInParameter(cmd, "LoginId", DbType.String, newUser.UserName);
                db.AddInParameter(cmd, "AccountUserId", DbType.String, newUser.AccountUserId);
                db.AddInParameter(cmd, "Pwd", DbType.String, newUser.PasswordHash);
                db.AddInParameter(cmd, "ApprovalPwd", DbType.String, newUser.ApprovalPasswordHash);
                db.AddInParameter(cmd, "SecurityStamp", DbType.String, newUser.SecurityStamp);
                db.AddInParameter(cmd, "AccessFailedCount", DbType.String, newUser.AccessFailedCount);
                db.AddInParameter(cmd, "IsActive", DbType.String, newUser.IsActive);
                db.AddInParameter(cmd, "Name", DbType.String, newUser.Name);
                db.AddInParameter(cmd, "Mobile", DbType.String, newUser.PhoneNumber);
                db.AddInParameter(cmd, "MobileConfirmed", DbType.String, newUser.PhoneNumberConfirmed);
                db.AddInParameter(cmd, "Email", DbType.String, newUser.Email);
                db.AddInParameter(cmd, "EmailConfirmed", DbType.String, newUser.EmailConfirmed);
                db.AddInParameter(cmd, "UserType", DbType.String, newUser.UserType);
                //--Audit Parameters --//
                Audit.AddAuditParameters(newUser, db, cmd);

                db.ExecuteNonQuery(cmd);

                return GetUserById(newUser.Id);
            }

        }



        /// <summary>
        /// Deletes a record from IdentityUser table.
        /// </summary>
        /// <param name="newUser">User to delete.</param>
        /// <returns>No of rows deleted.</returns>
        public Int32 RemoveUser(IdentityUser newUser)
        {
            //using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUser"))
            //{
            //    db.AddInParameter(cmd, "UserId", DbType.String, newUser.Id);

            //    return db.ExecuteNonQuery(cmd);
            //}

            using (DbCommand cmd = db.GetStoredProcCommand("uspLoginDeleteUser"))
            {
                //cmd.Parameters.Add()

                db.AddInParameter(cmd, "UserId", DbType.String, newUser.Id);
                //--Audit Parameters --//
                Audit.AddAuditParameters(newUser, db, cmd);

                return db.ExecuteNonQuery(cmd);
            }

        }

        /// <summary>
        /// Updates the IdentityUser record.
        /// </summary>
        /// <param name="newRole">User object with updated values.</param>
        /// <returns>Returns User.</returns>
        public IdentityUser SaveUser(IdentityUser newUser)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("uspLoginUpdateUser"))
            {
                db.AddInParameter(cmd, "Id", DbType.String, newUser.Id);
                db.AddInParameter(cmd, "LoginId", DbType.String, newUser.UserName);
                db.AddInParameter(cmd, "AccountUserId", DbType.String, newUser.AccountUserId);
                db.AddInParameter(cmd, "Pwd", DbType.String, newUser.PasswordHash);
                db.AddInParameter(cmd, "ApprovalPwd", DbType.String, newUser.ApprovalPasswordHash);
                db.AddInParameter(cmd, "SecurityStamp", DbType.String, newUser.SecurityStamp);
                db.AddInParameter(cmd, "AccessFailedCount", DbType.String, newUser.AccessFailedCount);
                db.AddInParameter(cmd, "IsActive", DbType.String, newUser.IsActive);
                db.AddInParameter(cmd, "Name", DbType.String, newUser.Name);
                db.AddInParameter(cmd, "Mobile", DbType.String, newUser.PhoneNumber);
                db.AddInParameter(cmd, "MobileConfirmed", DbType.String, newUser.PhoneNumberConfirmed);
                db.AddInParameter(cmd, "Email", DbType.String, newUser.Email);
                db.AddInParameter(cmd, "EmailConfirmed", DbType.String, newUser.EmailConfirmed);
                
                Audit.AddAuditParameters(newUser, db, cmd);

                db.ExecuteNonQuery(cmd);

                return GetUserById(newUser.Id);
            }
        }

        /// <summary>
        /// Returns the password hash by user ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Returns hashed password string.</returns>
        public String GetPasswordHash(String userId)
        {
            IdentityUser user = GetUserById(userId);

            return user.PasswordHash;
        }
    }
}
