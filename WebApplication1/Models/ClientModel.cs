using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ClientInfo
    {        
        [Key]
        public int clientID { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
    }

    public class OrderInfo
    {
        [Key]
        public int orderID { get; set; }

        public int clientID { get; set; }

        public string orderDate { get; set; }

        public virtual List<OrderItem> orderItems { get; set; }
    }

    public class OrderItem
    {
        [Key]
        public int ID { get; set; }

        public int orderID { get; set; }

        public int productID { get; set; }

        public int quantity { get; set; }
    }
}