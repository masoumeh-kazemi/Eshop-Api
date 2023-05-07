using Common.Applications;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create;

public class CreateRoleCommandHandler:IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var rolePermissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            rolePermissions.Add(new RolePermission(f));
        });
        var role = new Role(request.Title, rolePermissions);
        _repository.Add(role);
        await _repository.Save();
        return OperationResult.Success();
    }
}