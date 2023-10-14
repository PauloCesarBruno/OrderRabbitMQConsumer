using OrderConsumerAPI.Messages;

namespace OrderConsumerAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(CellConcertOrder order);
    }
}
