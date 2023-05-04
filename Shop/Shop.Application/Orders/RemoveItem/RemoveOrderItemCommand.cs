using Common.Applications;
using FluentValidation;

namespace Shop.Application.Orders.RemoveItem;

public record RemoveOrderItemCommand(long ItemId, long UserId) : IBaseCommand;