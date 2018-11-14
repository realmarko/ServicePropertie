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
    public class RepositoryPropertyType : IRepositoryPropertyType
    {
        string connectionString;
        public RepositoryPropertyType()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString;
        }

        public List<PropertyType> GetAllPropertyType()
        {
            List<PropertyType> listPropertyTypes = new List<PropertyType>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_GetPropertyType", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PropertyType propertyTypes = new PropertyType
                    {
                        id = reader.GetInt32(0),
                        text = reader.GetString(1)
                    };
                    listPropertyTypes.Add(propertyTypes);

                }
            }

            return listPropertyTypes;
        }
    }
}