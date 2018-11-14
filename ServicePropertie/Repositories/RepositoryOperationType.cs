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
    public class RepositoryOperationType : IRepositoryOperationType
    {
        string connectionString = string.Empty;
        public RepositoryOperationType()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<OperationType> GetAllOperationType()
        {
            List<OperationType> list = new List<OperationType>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("store_GetOperationType", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OperationType
                    {
                        id = reader.GetInt32(0),
                        text = reader.GetString(1)

                    });
                }
            }
            return list;
        }

        public OperationType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(OperationType item)
        {
            throw new NotImplementedException();
        }

        public OperationType Update(int id, OperationType item)
        {
            throw new NotImplementedException();
        }
    }
}