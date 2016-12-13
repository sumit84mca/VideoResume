using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Masters
    {        
        //public static DataTable GetUserAddress(String userId)
        //{
        //    ChangeAddressViewModel am = new ChangeAddressViewModel();
        //    DataTable dt = SqlHelper.ExecuteDataset(ConnectionHandler.ConString, CommandType.StoredProcedure, "uspGetUserAddress",
        //        new SqlParameter("@UserId", userId)).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        am.UserId = userId;
        //        am.AddressLine1 = dt.Rows[0]["AddressLine1"].ToString();
        //        am.AddressLine2 = dt.Rows[0]["AddressLine2"].ToString();
        //        am.AddressLine3 = dt.Rows[0]["AddressLine3"].ToString();
        //        am.Country = dt.Rows[0]["CountryId"].ToString();
        //        am.State = dt.Rows[0]["StateId"].ToString();
        //        am.City = dt.Rows[0]["CityId"].ToString();
        //        am.PIN = dt.Rows[0]["PIN"].ToString();
        //    }
        //    return am;
        //}
    }
}
