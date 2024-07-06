using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZoneTask.Core.Entities
{
    public class Store
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Store name is required")]
        [StringLength(100, ErrorMessage = "Store name cannot be longer than 100 characters")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string ManagerName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        [InverseProperty("Store")]
        public ICollection<StoreItem> StoreItems { get; set; } = new HashSet<StoreItem>();
    }
}
