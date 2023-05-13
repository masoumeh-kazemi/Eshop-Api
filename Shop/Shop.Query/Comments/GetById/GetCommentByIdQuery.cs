using System.Net.Sockets;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById;

public record GetCommentByIdQuery(long CommentId) : IQuery<CommentDto?>;
internal class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ShopContext _context;

    public GetCommentByIdQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId, cancellationToken: cancellationToken);

        return comment.Map();
    }
}