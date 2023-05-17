using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
    }
}

public class GetProductByFilterQueryHandler : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    private readonly ShopContext _context;

    public GetProductByFilterQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Products.OrderByDescending(d => d.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.Slug))
            result.Where(f => f.Slug == @params.Slug);

        if (!string.IsNullOrWhiteSpace(@params.Title))
            result.Where(f => f.Title.Contains(@params.Title));

        if (@params.Id != null)
            result.Where(f => f.Id == @params.Id);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new ProductFilterResult()
        {
            Data = result.Skip(skip).Take(@params.Take).Select(s=>s.MapListData()).ToList(),
            FilterParams = @params
        };

        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}