using System;

namespace Oreders.API.Dtos
{
    public class OrdersDto
    {
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public int UserId { get; set; }
        public int orderId { get; set; }
           }
}