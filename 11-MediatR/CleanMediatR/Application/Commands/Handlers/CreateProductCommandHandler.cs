using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductInMemoryRepository _productInMemoryRepository;

        public CreateProductCommandHandler(IProductInMemoryRepository productInMemoryRepository)
        {
            _productInMemoryRepository = productInMemoryRepository;
        }

        public async Task<string> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product() { Id = command.ProducId.ToString()
                                        , Name = command.Name.ToString()
                                        , Price = command.Price };

            return (await _productInMemoryRepository.Create(product)).Id;
        }
    }
}
