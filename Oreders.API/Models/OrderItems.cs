using System.ComponentModel.DataAnnotations;

namespace Oreders.API.Models
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemsId { get; set; }
        public Items Items { get; set; }




    }
}