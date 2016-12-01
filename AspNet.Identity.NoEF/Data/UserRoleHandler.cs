using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF.Data
{
    /// <summary>
    /// Handler for 'AspNetIdentity_UserRole' table.
    /// </summary>
    internal class UserRoleHandler : BaseHandler
    {
        /// <summary>
        /// Returns the list of roles assigned to a User ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of role names.</returns>
        public List<String> GetRolesByUserId(String userId)
        {
            List<String> Roles = new List<string>();

            using (DbCommand cmd = db.GetStoredProcCommand("AI_GetUserRole"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                using (IDataReader reader = db.ExecuteReader(cmd)) 
                {
                    while (reader.Read())
                    {
                        Roles.Add(Convert.ToString(reader["RoleId"]));
                    }
                }
            }

            return Roles;
        }

        /// <summary>
        /// Adds a record to 'AspNetIdentity_UserRole' table.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="roleId">Role ID</param>
        /// <returns>Returns the no of records inserted.</returns>
        public Int32 AddRole(String userId, String roleId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_AddUserRole"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);
                db.AddInParameter(cmd, "RoleId", DbType.String, roleId);

                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Deletes a record from 'AspNetIdentity_UserRole' table.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="roleId">Role ID</param>
        /// <returns>Returns the no of records deleted.</returns>
        public Int32 RemoveRole(String userId, String roleId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUserRole"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);
                db.AddInParameter(cmd, "RoleId", DbType.String, roleId);

                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Deletes all records from 'AspNetIdentity_UserRole' table by User ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Returns the no of records deleted.</returns>
        public Int32 RemoveAllRoles(String userId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUserRoleAllByUserId"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                return db.ExecuteNonQuery(cmd);
            }
        }
    }
}
