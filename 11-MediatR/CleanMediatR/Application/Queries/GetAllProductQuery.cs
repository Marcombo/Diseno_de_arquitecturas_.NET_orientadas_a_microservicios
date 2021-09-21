using System.Collections.Generic;
using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public record GetAllProductQuery() : IRequest<IEnumerable<ProductResponse>>;
}
