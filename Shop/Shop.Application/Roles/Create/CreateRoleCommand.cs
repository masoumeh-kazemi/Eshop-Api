using Common.Applications;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;