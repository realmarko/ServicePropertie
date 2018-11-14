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
    public class RepositoryPhoto : IRepositoryPhoto
    {
        string connectionString = string.Empty;
        public RepositoryPhoto()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PhotoRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhotoRequest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(string photoName,int propertyId)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PhotoName", photoName);
                cmd.Parameters.AddWithValue("@PropertyId", propertyId);

                res = cmd.ExecuteNonQuery();
            }

                return res;
        }

        public PhotoRequest Update(int id, PhotoRequest item)
        {
            throw new NotImplementedException();
        }
    }
}