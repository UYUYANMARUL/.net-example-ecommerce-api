using ETicaretAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text.Json.Serialization;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntity
    {

        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem>? OrderItems { get; set; }
        [JsonIgnore]
        public ICollection<BasketItem>? BasketItems { get; set; }
        public ICollection<ProductImageFile>? ProductImageFiles { get; set; }
        public ICollection<ProductSpec> ProductSpecs { get; set; }
        public Category? Category { get; set; }
        public bool IsDeleted { get; set; }

    }
}
