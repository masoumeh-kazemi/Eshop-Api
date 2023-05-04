using Common.Applications;
using Common.Applications;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Application.Categories.Edit;

public class EditCategorycommandHandler:IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public EditCategorycommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.Id);
        category.Edit(request.Title,request.Slug,request.SeoData,_domainService);
        if(category == null)
            return OperationResult.NotFound();
        await _repository.Save();
        return OperationResult.Success();
    }
}