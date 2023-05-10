using Common.Applications.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.Password)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
            .NotNull()
            .MinimumLength(4).WithMessage("کلمه عبور باید بیشتر از 4 کاراکتر باشد");
    }
}