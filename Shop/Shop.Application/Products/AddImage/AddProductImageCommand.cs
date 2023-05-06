using Common.Applications;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage;

public class AddProductImageCommand:IBaseCommand
{
    public IFormFile ImageFile { get; private set; }
    public long ProductId { get; internal set; }
    public int Sequence { get; private set; }
}