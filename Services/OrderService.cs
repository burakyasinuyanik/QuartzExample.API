using QuartzExample.API.Data;

namespace QuartzExample.API.Services
{
    public class OrderService(AppDbContext context) : IOrderService
    {
        public void OrderStatusCheck()
        {
           var orders=context.Orders;

            foreach (var item in orders)
            {
                item.Status = "waiting";
                Console.WriteLine($"{item.Id}-order status={item.Status}");
            }
        }
    }
}
