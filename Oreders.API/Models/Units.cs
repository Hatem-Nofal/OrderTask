using System.Collections.Generic;

namespace Oreders.API.Models
{
    public class Units
    {
        public int Id { get; set; }
        public string unitName { get; set; }
        public ICollection<Items> Items { get; set; }


    }
}