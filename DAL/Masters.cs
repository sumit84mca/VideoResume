using AspNet.Identity.NoEF.Test.Models;
using DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Masters
    {
        public static List<Country> GetCountryList()
        {
            List<Country> countries = new List<Country>();
            SqlDataReader iread = SqlHelper.ExecuteReader(ConnectionHandler.ConString, CommandType.StoredProcedure, "uspGetCountryList");

            while (iread.Read())
            {
                countries.Add(GetCountry(iread));
            }

            return countries;
        }
        private static Country GetCountry(SqlDataReader iread)
        {
            Country country = new Country();
            country.CountryId = Convert.ToInt32(iread["CountryId"]);
            country.CountryName = Convert.ToString(iread["CountryName"]);

            return country;
        }
        public static List<State> GetStateList(int id)
        {
            List<State> states = new List<State>();
            SqlDataReader iread = SqlHelper.ExecuteReader(ConnectionHandler.ConString, CommandType.StoredProcedure, "uspGetStateList",
                new SqlParameter("@CountryId", id));

            while (iread.Read())
            {
                states.Add(GetState(iread));
            }

            return states;
        }
        private static State GetState(SqlDataReader iread)
        {
            State state = new State();
            state.StateId = Convert.ToInt32(iread["StateId"]);
            state.StateName = Convert.ToString(iread["StateName"]);
            state.CountryId = Convert.ToInt32(iread["CountryFkId"]);

            return state;
        }
        public static List<City> GetCityList(int id)
        {
            List<City> cities = new List<City>();
            SqlDataReader iread = SqlHelper.ExecuteReader(ConnectionHandler.ConString, CommandType.StoredProcedure, "uspGetCityList",
                new SqlParameter("@StateId", id));

            while (iread.Read())
            {
                cities.Add(GetCity(iread));
            }

            return cities;
        }
        private static City GetCity(SqlDataReader iread)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(iread["CityId"]);
            city.CityName = Convert.ToString(iread["CityName"]);
            city.StateId = Convert.ToInt32(iread["StateFkId"]);

            return city;
        }
    }
}
