using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Item name is required")]
        [StringLength(100, ErrorMessage = "Item name cannot be longer than 100 characters")]
        public string? Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Manufacturer { get; set; }
        public DateTime? ExpirationDate { get; set; }
        [InverseProperty("Item")]
        public ICollection<StoreItem> StoreItems { get; set; } = new HashSet<StoreItem>();
    }
}
