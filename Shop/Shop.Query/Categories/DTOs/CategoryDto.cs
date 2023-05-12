using Common.Domain.ValueObjects;
using Common.Query;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Shop.Query.Categories.DTOs;

public class CategoryDto:BaseDto
{
    public string Title { get;  set; }
    public string Slug { get;  set; }
    public SeoData SeoData { get;  set; }
    public List<ChildCategoryDto> Childs { get;  set; }
}