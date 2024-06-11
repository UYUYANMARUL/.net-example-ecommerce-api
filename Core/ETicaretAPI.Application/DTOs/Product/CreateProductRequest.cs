using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
   public class CreateProductRequest
    {
        public List<AddSpecTo> Specs { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
