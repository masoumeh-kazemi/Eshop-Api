using AngleSharp.Io;
using Common.Applications;
using Common.Applications._Utilities;
using Common.Applications.FileUtil.Interfaces;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Products.Edit;

public class EditProductCommand:IBaseCommand
{
    public long ProductId { get; private set; }
    public string Title { get; private set; }
    public IFormFile? ImageName { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategroyId { get; private set; }
    public long SecondarySubCategroyId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public Dictionary<string,string> Specifications { get; private set; }

    public EditProductCommand(long productId, string title, IFormFile? imageName, string description, long categoryId, long subCategroyId, long secondarySubCategroyId, string slug, SeoData seoData, Dictionary<string, string> specifications)
    {
        ProductId = productId;
        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategroyId = subCategroyId;
        SecondarySubCategroyId = secondarySubCategroyId;
        Slug = slug;
        SeoData = seoData;
        Specifications = specifications;
    }
}

internal class EditProductCommandHandler:IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _localFileService;

    public EditProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService localFileService)
    {
        _domainService = domainService;
        _repository = repository;
        _localFileService = localFileService;

    }
    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null) 
            return OperationResult.NotFound();

        product.Edit(request.Title, request.Description, request.CategoryId, request.SecondarySubCategroyId
        , request.SecondarySubCategroyId,_domainService,request.Slug, request.SeoData
        );
        var oldImage = product.ImageName;
        if (request.ImageName != null)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageName, 
                Directories.ProductImages);
            product.SetProductImage(imageName);
        }
        var specifications = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        product.SetSpecification(specifications);
        await _repository.Save();
        RemoveOldImage(request.ImageName, oldImage);
        return OperationResult.Success();
    }

    private void RemoveOldImage(IFormFile imageName, string oldImageName)
    {
        if (imageName != null)
        {
            _localFileService.DeleteFile(Directories.ProductImages, oldImageName);
        }

    }
}