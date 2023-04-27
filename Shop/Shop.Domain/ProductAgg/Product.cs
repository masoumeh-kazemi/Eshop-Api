using System.Net.Mime;
using Common.Domain;
using Common.Domain.Exeptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;

namespace Shop.Domain.ProductAgg;

public class Product:AggregateRoot
{
    private Product()
    {

    }
    public Product(string title, string imageName, string description, long categoryId, long subCategroyId, long secondarySubCategroyId,
        string slug, SeoData seoData)
    {
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

    public void Edit(string title, string imageName, string description, long categoryId, long subCategroyId, long secondarySubCategroyId,
        string slug, SeoData seoData)
    {
        Title = title;
        ImageName = imageName;
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

    public void RemoveImage(long id)
    {
        var image = Images.FirstOrDefault(f => f.Id == id);
        if (image == null)
            return;
        Images.Remove(image);
    }

    public void SetSpecification(List<ProductSpecification> specification)
    {
        specification.ForEach(s=>s.ProductId = Id);
        Specifications = specification;
    }

    public void Guard(string title, string imageNme, string description)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(imageNme, nameof(imageNme));
        NullOrEmptyDomainDataException.CheckString(description, nameof(description));
    }
}