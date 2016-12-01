using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF.Data
{
    /// <summary>
    /// Handler for 'AspNetIdentity_UserClaim' table.
    /// </summary>
    internal class UserClaimHandler : BaseHandler
    {
        /// <summary>
        /// Returns a ClaimsIdentity based on the user ID.
        /// </summary>
        /// <param name="userId">UserId to look for.</param>
        /// <returns>Returns ClaimsIdentity.</returns>
        public ClaimsIdentity GetClaimsByUserId(String userId) 
        {
            ClaimsIdentity claims = new ClaimsIdentity();

            using (DbCommand cmd = db.GetStoredProcCommand("AI_GetUserClaim"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Claim claim = new Claim(Convert.ToString(reader["ClaimType"]), Convert.ToString(reader["ClaimValue"]));

                        claims.AddClaim(claim);
                    }
                }
            }

            return claims;
        }

        /// <summary>
        /// Adds a record to AspNetIdentity_UserClaim table.
        /// </summary>
        /// <param name="claim">Claim to add</param>
        /// <param name="userId">User ID</param>
        /// <returns>Returns the no of claims added.</returns>
        public Int32 AddClaim(Claim claim, String userId) {

            using (DbCommand cmd = db.GetStoredProcCommand("AI_AddUserClaim"))
            {
                db.AddInParameter(cmd, "ClaimType", DbType.String, claim.Type);
                db.AddInParameter(cmd, "ClaimValue", DbType.String, claim.Value);

                db.AddInParameter(cmd, "UserId", DbType.String, userId);
                
                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Deletes a record from AspNetIdentity_UserClaim table.
        /// </summary>
        /// <param name="claim">Claim to delete</param>
        /// <param name="userId">User ID</param>
        /// <returns>Returns the no of claims deleted.</returns>
        public Int32 RemoveClaim(Claim claim, String userId) {

            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUserClaim"))
            {
                db.AddInParameter(cmd, "ClaimType", DbType.String, claim.Type);
                db.AddInParameter(cmd, "ClaimValue", DbType.String, claim.Value);

                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                return db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Deletes all records from AspNetIdentity_UserClaim table by user ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Returns the no of records deleted.</returns>
        public Int32 RemoveAllClaims(String userId)
        {

            using (DbCommand cmd = db.GetStoredProcCommand("AI_DeleteUserClaimAllByUserId"))
            {
                db.AddInParameter(cmd, "UserId", DbType.String, userId);

                return db.ExecuteNonQuery(cmd);
            }
        }

    }
}
