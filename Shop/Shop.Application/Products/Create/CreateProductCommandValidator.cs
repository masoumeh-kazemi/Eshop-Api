using Common.Applications.Validation;
using Common.Applications.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("Slug"));

        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.ImageFile)
            .JustImageFile();

    }
}