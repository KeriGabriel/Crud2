using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Crud2.Models;

namespace Crud2.Data
{
    public class SQLData
    {
        string conString = ConfigurationManager.ConnectionStrings["dbConnection"].ToString();
        // get Master List
        public List<Product> GetMasterList()
        {
            List<Product> Masterlist = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProductList_Gabriel";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable MasterDT = new DataTable();

                connection.Open();
                adapter.Fill(MasterDT);
                connection.Close();

                foreach (DataRow DR in MasterDT.Rows)
                {
                    Masterlist.Add(new Product
                    {
                        Id = Convert.ToInt32(DR["Id"]),
                        ProductName = DR["ProductName"].ToString(),
                        SupplierId = Convert.ToInt32(DR["SupplierId"]),
                        UnitPrice = Convert.ToDecimal(DR["UnitPrice"]),
                        Package = DR["Package"].ToString(),
                        IsDiscontinued = DR["IsDiscontinued"].ToString()
                    }) ;
                }
            }
            return Masterlist;
        }

        public void AddToOrder()
        {

        }
    }
}