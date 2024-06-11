using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
   public class OrderBlock : BaseEntity
    {
        public bool Cancelled { get; set; } = false;
        public bool Finished { get; set; } = false;
        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public ICollection<Order>? Order { get; set; }
        
    }
}
