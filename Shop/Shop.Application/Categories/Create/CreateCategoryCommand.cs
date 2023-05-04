using System.Runtime.InteropServices.ComTypes;
using Common.Applications;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Create;

public record CreateCategoryCommand(string Title, string Slug, SeoData SeoData) : IBaseCommand;