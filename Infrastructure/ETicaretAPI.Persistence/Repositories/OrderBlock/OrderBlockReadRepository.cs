using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class OrderBlockReadRepository : ReadRepository<OrderBlock>, IOrderBlockReadRepository
    {
        public OrderBlockReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
