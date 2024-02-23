using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerID { get; set; }           
        public decimal TotalAmount { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}