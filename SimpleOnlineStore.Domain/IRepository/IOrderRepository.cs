using SimpleOnlineStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOnlineStore.Domain.IRepository
{
    public interface IOrderRepository
    {
         public Task<Order> AddAsync(Order order);
    }
}
