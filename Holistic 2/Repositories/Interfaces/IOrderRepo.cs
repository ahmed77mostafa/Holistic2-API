using Holistic_2.Data.DTOs;

namespace Holistic_2.Repositories.Interfaces
{
    public interface IOrderRepo
    {
        List<OrderResponse> GetOrders();
        bool AddOrder(OrderRequest orderRequest);
        bool UpdateOrder(int Id, OrderWithProduct orderDto);
        bool DeleteOrder(int Id);
    }
}
