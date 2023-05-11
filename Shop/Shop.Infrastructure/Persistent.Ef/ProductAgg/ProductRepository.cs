using Common.Domain.Repository;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ShopContext context) : base(context)
    {
    }
}

