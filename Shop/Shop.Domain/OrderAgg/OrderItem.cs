using Common.Domain;
using Common.Domain.Exeptions;

namespace Shop.Domain.OrderAgg;

public class OrderItem:BaseEntity
{
    public OrderItem(long inventoryId, int count, int price)
    {
        PriceGaurd(price);
        CountGuard(count);

        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }
    public long OrderId { get; internal set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Price * Count;

    public void ChangeCount(int newCount)
    {
        CountGuard(newCount);
        Count = newCount;
    }

    public void SetPrice(int newPrice)
    {
        PriceGaurd(newPrice);
        Price = newPrice;
    }

    public void PriceGaurd(int newPrice)
    {
        if (newPrice < 1)
            throw new InvalidDomainDataException("مبلغ کالا نامعتبر است");
    }

    public void CountGuard(int count)
    {
        if (count < 1)
            throw new InvalidDomainDataException();
    }
}