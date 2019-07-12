using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oreders.API.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }

        public int Amount { get; set; }
        public int UnitsId { get; set; }
        public Units Units { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }

    }
}