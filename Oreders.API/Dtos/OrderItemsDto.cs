using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Dtos
{
    public class OrderItemsDto
    {

        public int itemid { get; set; }
        public string itemsname { get; set; }

        public int amount { get; set; }
        public int unitid { get; set; }

        public int userId { get; set; }

    }
}
