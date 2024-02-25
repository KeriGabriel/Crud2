using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Crud2.Models;
using System.Security.Policy;

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

        public bool AddToOrder(Product product, Order order, Customer customer)
        {
            int x = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("InsertCustomerAndOrder_Gabriel", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customer.Id);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                //Change this later (right now quanity is set to one)
                cmd.Parameters.AddWithValue("@TotalAmount", product.UnitPrice);
                cmd.Parameters.AddWithValue("@OrderNumber", null);
                cmd.Parameters.AddWithValue("@OrderItemId", null);
                cmd.Parameters.AddWithValue("@ProductId", product.Id);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                //change later
                cmd.Parameters.AddWithValue("@Quantity", 1);
                cmd.Parameters.AddWithValue("@NewOrderID", null);

                connection.Open();
                x = cmd.ExecuteNonQuery();
                connection.Close();
            }
            if (x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}











