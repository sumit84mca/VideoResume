using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace AspNet.Identity.NoEF.Data
{
    /// <summary>
    /// Handler for 'AspNetIdentity_Role' table.
    /// </summary>
    internal class RoleHandler: BaseHandler
    {
        /// <summary>
        /// Returns the Identity Role object.
        /// </summary>
        /// <param name="reader">IDataReader object with Identity role data.</param>
        /// <returns>Returns IdentityRole.</returns>
        private IdentityRole GetRole(IDataReader reader)
        {
            IdentityRole newRole = null;

            if (reader.Read())
            {
                newRole = new IdentityRole();

                newRole.Id = Convert.ToString(reader["RoleId"]);
                newRole.Name = Convert.ToString(reader["RoleName"]);
                newRole.Description = Convert.ToString(reader["Description"]);
            }

            return newRole;
        }

        /// <summary>
        /// Returns the Role by role Id.
        /// </summary>
        /// <param name="roleId">Role Id</param>
        /// <returns>Returns Role.</returns>
        public IdentityRole GetRoleById(String roleId) 
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_GetRole"))
            {
                db.AddInParameter(cmd, "RoleId", DbType.String, roleId);

                return GetRole(db.ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Returns the Role by role name.
        /// </summary>
        /// <param name="roleName">Name of the Role.</param>
        /// <returns>Returns Role.</returns>
        public IdentityRole GetRoleByName(String roleName)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_GetRole"))
            {
                db.AddInParameter(cmd, "RoleName", DbType.String, roleName);

                return GetRole(db.ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Adds new record to IdentityRole table.
        /// </summary>
        /// <param name="newRole">Role to add.</param>
        /// <returns>Returns Role.</returns>
        public IdentityRole AddRole(IdentityRole newRole)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_AddRole"))
            {
                db.AddInParameter(cmd, "RoleId", DbType.String, newRole.Id);
                db.AddInParameter(cmd, "RoleName", DbType.String, newRole.Name);
                db.AddInParameter(cmd, "Description", DbType.String, newRole.Description);

                db.ExecuteNonQuery(cmd);

                return GetRoleById(newRole.Id);
            }
        }

        /// <summary>
        /// Deletes a record from IdentityRole table.
        /// </summary>
        /// <param name="roleId">ID of the role to delete.</param>
        /// <returns>No of rows deleted.</returns>
        public Int32 RemoveRole(String roleId)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteRole"))
            {
                db.AddInParameter(cmd, "RoleId", DbType.String, roleId);

                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Updates the IdentityRole record.
        /// </summary>
        /// <param name="newRole">Role object with updated values.</param>
        /// <returns>Returns Role.</returns>
        public IdentityRole SaveRole(IdentityRole newRole)
        {
            using (DbCommand cmd = db.GetStoredProcCommand("AI_SaveRole"))
            {
                db.AddInParameter(cmd, "RoleId", DbType.String, newRole.Id);
                db.AddInParameter(cmd, "RoleName", DbType.String, newRole.Name);
                db.AddInParameter(cmd, "Description", DbType.String, newRole.Description);

                db.ExecuteNonQuery(cmd);

                return GetRoleById(newRole.Id);
            }
        }
    }
}
