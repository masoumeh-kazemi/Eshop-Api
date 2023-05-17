using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById;

public record GetProductQueryByIdQuery(long ProductId) : IQuery<ProductDto?>;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductQueryByIdQuery, ProductDto?>
{
    private readonly ShopContext _context;

    public GetProductByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductQueryByIdQuery request, CancellationToken cancellationToken)
    {
        var product =await _context.Products
            .FirstOrDefaultAsync(f=>f.Id == request.ProductId, cancellationToken);

        var model = product.Map();
        if (model == null)
            return null;

        await model.SetCategories(_context);
        return model;
    }
}