using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Guid OrderBlockId { get; set; }
        public OrderBlock OrderBlock { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public float? TotalPrice { get; set; }
        public bool Ordered { get; set; } = false;
        public DateTime? OrderedDate { get; set; }
        public bool Confirmed { get; set; } = false;
        public DateTime? ConfirmedDate { get; set; }
        public bool Completed { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public bool IsValid { get; set; } = true;
        public DateTime? NotValidDate { get; set; }
    }
}
