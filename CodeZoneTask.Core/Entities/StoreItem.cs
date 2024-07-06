using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Core.Entities
{
    public class StoreItem
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
