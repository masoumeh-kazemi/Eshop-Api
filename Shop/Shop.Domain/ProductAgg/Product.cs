using System.Net.Mime;
using Common.Domain;
using Common.Domain.Exeptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg;

public class Product:AggregateRoot
{
    private Product()
    {

    }
    public Product(string title, string imageName, string description, long categoryId, long subCategroyId
        ,long secondarySubCategroyId, IProductDomainService domainService, string slug, SeoData seoData)
    {
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        Guard(title, slug, description, domainService);
        Title = title;
        ImageName = imageName;
        Description = description;
        CategoryId = categoryId;
        SubCategroyId = subCategroyId;

        SecondarySubCategroyId = secondarySubCategroyId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }
    public string Title { get; private set; }
    public string ImageName { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategroyId { get; private set; }
    public long SecondarySubCategroyId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }

    public void Edit(string title, string description, long categoryId, long subCategroyId
        , long secondarySubCategroyId, IProductDomainService domainService,string slug, SeoData seoData)
    {
        Guard(title, slug, description, domainService);
        Title = title;
        Description = description;
        CategoryId = categoryId;
        SubCategroyId = subCategroyId;
        SecondarySubCategroyId = secondarySubCategroyId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public void AddImage(ProductImage image)
    {
        image.ProductId = Id;
        Images.Add(image);
    }

    public void SetProductImage(string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        ImageName = imageName;
    }

    public string RemoveImage(long id)
    {
        var image = Images.FirstOrDefault(f => f.Id == id);
        if (image == null)
            throw new NullOrEmptyDomainDataException("عکس یافت نشد");

        Images.Remove(image);
        return image.ImageName;
    }

    public void SetSpecification(List<ProductSpecification> specification)
    {
        specification.ForEach(s=>s.ProductId = Id);
        Specifications = specification;
    }

    private void Guard(string title, string slug, string description,IProductDomainService domainService)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(description, nameof(description));
        NullOrEmptyDomainDataException.CheckString(Slug, nameof(Slug));
        if (slug != Slug)
            if (domainService.SlugIsExist(slug.ToSlug()))
                throw new SlugIsDuplicateException();
    }
}