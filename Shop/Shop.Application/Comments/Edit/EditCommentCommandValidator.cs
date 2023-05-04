﻿using Common.Applications.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandValidator:AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator(string text)
    {
        RuleFor(r => r.Text)
            .NotNull()
            .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نظر", 5));
    }
}