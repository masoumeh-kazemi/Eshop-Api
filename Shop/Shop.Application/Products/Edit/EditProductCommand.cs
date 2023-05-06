using AngleSharp.Io;
using Common.Applications;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
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