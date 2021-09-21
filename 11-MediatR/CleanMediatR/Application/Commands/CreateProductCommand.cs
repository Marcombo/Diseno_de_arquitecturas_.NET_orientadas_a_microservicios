using System;
using MediatR;

namespace Application.Commands
{
    public record CreateProductCommand(Guid ProducId, string Name, double Price)
                : IRequest<string>;
    
}

