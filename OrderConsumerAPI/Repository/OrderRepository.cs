using Microsoft.EntityFrameworkCore;
using OrderConsumerAPI.Data.Context;
using OrderConsumerAPI.Messages;

namespace OrderConsumerAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<SQLContext> _context;

        public OrderRepository(DbContextOptions<SQLContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(CellConcertOrder order)
        {
            if (order == null) return false;
            await using var _db = new SQLContext(_context);
            _db.orders.Add(order);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
