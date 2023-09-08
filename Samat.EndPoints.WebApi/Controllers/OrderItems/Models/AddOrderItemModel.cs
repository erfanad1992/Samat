using Samat.Applications.Contracts.Commands;

namespace Samat.EndPoints.WebApi.Controllers.OrderItems.Models
{
    public class AddOrderItemModel
    {   
        public long ProductId { get; set; }
        public int Quantity { get;  set; }

        internal AddOrderItemToOrderCommand ToCommand(long orderId)
        {
            return new AddOrderItemToOrderCommand(orderId, ProductId,Quantity);
        }
    }
}
