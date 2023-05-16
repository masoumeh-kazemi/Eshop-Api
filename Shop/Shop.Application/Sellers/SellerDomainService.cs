using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers;

public class SellerDomainService : ISellerDomainService
{
    public bool CheckSellerInfo(Seller seller)
    {
        throw new NotImplementedException();
    }

    public bool NationalCodeExistInDatabase(string nationalCode)
    {
        throw new NotImplementedException();
    }
}