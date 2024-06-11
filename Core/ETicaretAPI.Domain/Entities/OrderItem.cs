using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class OrderItem : BaseEntity
    {

        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public int Piece { get; set; }
        public int? DeliveredPiece { get; set; }
        public float? PiecePrice { get; set; }

    }
}
