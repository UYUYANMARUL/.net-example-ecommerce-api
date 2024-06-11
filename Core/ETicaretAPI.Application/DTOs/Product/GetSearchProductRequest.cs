using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetSearchProductRequest
    {
        public string? SearchValue { get; set; }
        public int DataSize { get; set; } = 4;
    }
}
