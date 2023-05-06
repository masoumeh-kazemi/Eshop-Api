using Common.Applications;
using Common.Applications._Utilities;
using Common.Applications.FileUtil.Interfaces;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage;

internal class RemoveProductImageCommandHandler:IBaseCommandHandler<RemoveProductImageCommand>
{
    private readonly IProductRepository _repository;
    private readonly IFileService _localFileService;

    public RemoveProductImageCommandHandler(IProductRepository repository, IFileService locFileService)
    {
        _repository = repository;
        _localFileService = locFileService;
    }
    public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null) 
            return OperationResult.NotFound();

        //delete image from database
        var imageName = product.RemoveImage(request.ImageId);
        await _repository.Save();

        //delete image from files
        _localFileService.DeleteFile(Directories.ProductGalleryImage, imageName);
        return OperationResult.Success();
    }
}