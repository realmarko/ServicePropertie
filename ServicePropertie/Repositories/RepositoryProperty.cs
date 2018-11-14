using ServicePropertie.Interfaces;
using ServicePropertie.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicePropertie.Repositories
{
    public class RepositoryProperty : IRepositoryProperty
    {
        string connectionString = string.Empty;
        public RepositoryProperty()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString;
        }
        public int SaveProperty(Property pdm)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_SaveProperty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Price", pdm.Price);
                cmd.Parameters.AddWithValue("@CoordX", pdm.CoordX);
                cmd.Parameters.AddWithValue("@CoordY", pdm.CoordY);
                cmd.Parameters.AddWithValue("@PropertyTypeId", pdm.PropertyTypeId);
                cmd.Parameters.AddWithValue("@OperationTypeId", pdm.OperationTypeId);
                cmd.Parameters.AddWithValue("@StateId", pdm.StateId);
                SqlParameter outparam = cmd.Parameters.Add("@PropertyId", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(outparam.Value);

            }

        }

        public List<Property> GetAllProperty()
        {
            List<Property> listPropertys = new List<Property>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_GetProperty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listPropertys.Add(
                    new Property
                    {
                        Id = reader.GetInt32(0),
                        PropertyType = reader.GetString(1),
                        CoordX = reader.GetString(2),
                        CoordY = reader.GetString(3),
                        Price = Convert.ToDouble(reader.GetDecimal(4))

                    });
                }
            }

            return listPropertys;
        }

        public Property GetPropertyByLatLng(string lat, string lng)
        {
            Property property = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_GetPropertyByLatLng", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Lat", lat);
                cmd.Parameters.AddWithValue("@Lng", lng);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    property = new Property
                    {
                        Id = reader.GetInt32(0),
                        PropertyType = reader.GetString(1),
                        CoordX = reader.GetString(2),
                        CoordY = reader.GetString(3),
                        Price = Convert.ToDouble(reader.GetDecimal(4))
                    };
                }

            }
            return property;
        }

        public Property GetPropertyById(int id)
        {
            Property property = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_GetPropertyById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    property = new Property
                    {
                        Id = reader.GetInt32(0),
                        PropertyType = reader.GetString(1),
                        CoordX = reader.GetString(2),
                        CoordY = reader.GetString(3),
                        Price = Convert.ToDouble(reader.GetDecimal(4))

                    };
                }

            }

            return property;
        }

        public int UpdateProperty(Property property)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("store_UpdateProperty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", property.Id);
                cmd.Parameters.AddWithValue("@PropertyType", property.PropertyType);
                cmd.Parameters.AddWithValue("@Price", property.Price);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteProperty(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_DeleteProperty", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}