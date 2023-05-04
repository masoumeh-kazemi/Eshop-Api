using Common.Applications;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Categories.AddChild;

public record AddChildCategoryCommand(long ParentId,string Title, string Slug, SeoData SeoData) : IBaseCommand;