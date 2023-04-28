using System.Runtime.InteropServices.ComTypes;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Create;

public record CreateCategoryCommand(string title, string slug, SeoData seoData) : IBaseCommand;