using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Oreders.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItems> orderItems { get; set; }


    }
}