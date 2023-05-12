using Common.Applications;
using Common.Query;
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById;

public record GetCategoryByIdQuery(long CategoryId) : IQuery<CategoryDto>;