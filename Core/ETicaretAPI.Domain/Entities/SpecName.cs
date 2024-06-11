using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class SpecName:BaseEntity
    {
        public string SpecDetailName { get; set; }
        public bool IsItNumber { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Category>? Category { get; set; }
    }
}
