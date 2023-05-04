using Common.Applications;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.Create;

public class CreateProductCommand : IBaseCommand
{
    public CreateProductCommand(string title, IFormFile imageFile, string description, long categoryId, long subCategroyId
        , long secondarySubCategroyId, string slug, SeoData seoData, Dictionary<string, string> specifications)
    {
        Title = title;
        ImageFile = imageFile;
        Description = description;
        CategoryId = categoryId;
        SubCategroyId = subCategroyId;
        SecondarySubCategroyId = secondarySubCategroyId;
        Slug = slug;
        SeoData = seoData;
        Specifications = specifications;
    }
    public string Title { get; private set; }
    public IFormFile ImageFile { get; private set; }
    public string Description { get; private set; }
    public long CategoryId { get; private set; }
    public long SubCategroyId { get; private set; }
    public long SecondarySubCategroyId { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public Dictionary<string, string> Specifications { get; private set; }

}