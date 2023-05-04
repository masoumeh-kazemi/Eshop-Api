using Common.Applications;
using FluentValidation;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(long Id, CommentStatus Status): IBaseCommand;

