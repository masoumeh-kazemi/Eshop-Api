using Common.Applications;
using FluentValidation;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInventory;

public class EditInventoryCommand : IBaseCommand
{
    public EditInventoryCommand(long sellerId, long inventoryId, int count, int price, int? discountDercentage)
    {
        SellerId = sellerId;
        InventoryId = inventoryId;
        Count = count;
        Price = price;
        Discountpercentage = discountDercentage;
    }
    public long SellerId { get; private set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? Discountpercentage { get; private set; }
}

public class EditInventoryCommandHandler : IBaseCommandHandler<EditInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public EditInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();
        seller.EditInventory(request.InventoryId, request.Count, request.Price, request.Discountpercentage);
        await _repository.Save();
        return OperationResult.Success();
    }
}


