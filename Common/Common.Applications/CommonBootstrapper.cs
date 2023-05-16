using Common.Applications.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Applications;

public class CommonBootstrapper
{
    public static void Init(IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
    }
}