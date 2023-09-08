using Samat.Applications.Contracts.Commands;

namespace Samat.EndPoints.WebApi.Controllers.Orders.Models
{
    public class CreateOrderModel
    {
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        internal CreateOrderCommand ToCommand()
        {
            return new CreateOrderCommand(CustomerId,OrderDate);
        }
    }
}
