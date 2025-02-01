using Quartz;
using QuartzExample.API.Services;

namespace QuartzExample.API.Job
{
    public class OrderStatusCheckJob(IOrderService orderService) : IJob
    {
        public static readonly JobKey Key = new JobKey("orderStatus-name", "order-name");
        public Task Execute(IJobExecutionContext context)
        {
            orderService.OrderStatusCheck();
            return Task.CompletedTask;
        }
    }
}
