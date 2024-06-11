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
    public class TUser : BaseEntity
    {
        public Guid name { get; set; }
        [JsonIgnore]
        public ICollection<TUser>? followers { get; set; }
        [JsonIgnore]
        public ICollection<TUser>? following { get; set; }
        public ICollection<TUser>? test { get; set; }

    }
}
