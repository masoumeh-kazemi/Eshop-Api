using Common.Applications;
using FluentValidation;

namespace Shop.Application.Products.RemoveImage;

public record RemoveProductImageCommand (long ProductId, long ImageId): IBaseCommand;