
using Common.Applications;
using Common.Applications._Utilities;
using Common.Applications.FileUtil.Interfaces;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create;

public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _locFileService;

    internal CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository
        , IFileService localFileService)
    {
        _domainService = domainService;
        _repository = repository;
        _locFileService = localFileService;
    }
    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _locFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
        var product = new Product(request.Title, imageName, request.Description, request.CategoryId, request.SubCategroyId
            , request.SecondarySubCategroyId, _domainService, request.Slug, request.SeoData);

        //for set id
        await _repository.Add(product);

        var specifications = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        product.SetSpecification(specifications);
        await _repository.Save();
        return OperationResult.Success();
    }
}