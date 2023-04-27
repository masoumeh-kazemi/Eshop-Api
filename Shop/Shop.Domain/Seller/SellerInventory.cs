﻿using Common.Domain;
using Common.Domain.Exeptions;

namespace Shop.Domain.Seller;

public class SellerInventory:BaseEntity
{
    public long SellerId { get; internal set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }

    public SellerInventory(long productId, int count, int price)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException();
        ProductId = productId;
        Count = count;
        Price = price;
    }


}