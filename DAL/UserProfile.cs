using AspNet.Identity.NoEF.Test.Models;
using DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserProfile
    {

        /// <summary>
        /// Returns the User address by user ID.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Returns User address.</returns>
        public static ChangeAddressViewModel GetUserAddress(String userId)
        {
            ChangeAddressViewModel am = new ChangeAddressViewModel();
            DataTable dt = SqlHelper.ExecuteDataset(ConnectionHandler.ConString, CommandType.StoredProcedure, "uspGetUserAddress",
                new SqlParameter("@UserId", userId)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                am.UserId = userId;
                am.AddressLine1 = dt.Rows[0]["AddressLine1"].ToString();
                am.AddressLine2 = dt.Rows[0]["AddressLine2"].ToString();
                am.AddressLine3 = dt.Rows[0]["AddressLine3"].ToString();
                am.Country = dt.Rows[0]["CountryId"].ToString();
                am.State = dt.Rows[0]["StateId"].ToString();
                am.City = dt.Rows[0]["CityId"].ToString();
                am.PIN = dt.Rows[0]["PIN"].ToString();
            }
            return am;
        }
        /// <summary>
        /// Update user address.
        /// </summary>
        /// <param name="newUser">User to add.</param>
        /// <returns>Returns User.</returns>
        public static int UpdateAddress(ChangeAddressViewModel address)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionHandler.ConString, CommandType.StoredProcedure, "uspUpdateUserAddress",
                new SqlParameter("@UserId", address.UserId),
                new SqlParameter("@AddressLine1", address.AddressLine1),
                new SqlParameter("@AddressLine2", address.AddressLine2),
                new SqlParameter("@AddressLine3", address.AddressLine3),
                new SqlParameter("@CountryId", address.Country),
                new SqlParameter("@StateId", address.State),
                new SqlParameter("@CityId", address.City),
                new SqlParameter("@PIN", address.PIN)
                );
            return Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
        }

    }
}

