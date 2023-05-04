using Common.Applications;

namespace Shop.Application.Orders.DecreaseItemCount;

public record DecreaseOrderItemCountCommand (long OrderItem, long UserId, int Count) : IBaseCommand;