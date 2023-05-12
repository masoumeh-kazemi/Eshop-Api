using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList;

public record GetCategoryListQuery : IQuery<List<CategoryDto>>;

internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ShopContext _context;

    public GetCategoryListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
        return result.Map();
    }
}
