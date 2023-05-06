using System.Diagnostics;
using Common.Applications;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create;

public class CreateSellerCommand: IBaseCommand
{
    public CreateSellerCommand(long userId, string shopName, string nationalCode)
    {
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
    }
    public long UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
}


public class CreateSellerCommandHandler:IBaseCommandHandler<CreateSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _domainService;

    public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _domainService);
        await _repository.Add(seller);
        await _repository.Save();
        return OperationResult.Success();
    }
}