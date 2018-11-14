using ServicePropertie.Interfaces;
using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicePropertie.Repositories
{
    public class RepositoryState : IRepositoryState
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString;
        public List<State> GetAllState()
        {
            List<State> states = new List<State>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_GetState",con);
                SqlDataReader reader =  cmd.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(new State
                    {
                        id = reader.GetInt32(0),
                        text = reader.GetString(1),
                        CountryId = reader.GetInt32(2)
                    });
                }

            }
            return states;
        }
    }
}