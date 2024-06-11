using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Basket :BaseEntity
    {
        public ICollection<BasketItem>? BasketItems { get;set; }
        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }
}
