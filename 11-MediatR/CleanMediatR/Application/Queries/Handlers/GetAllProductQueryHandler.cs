using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Responses;
using Domain.Interfaces.Repositories;
using MediatR;


namespace Application.Queries.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery,IEnumerable<ProductResponse>>
    {
        private readonly IProductInMemoryRepository _productInMemoryRepository;

        public GetAllProductQueryHandler(IProductInMemoryRepository productInMemoryRepository)
        {
            _productInMemoryRepository = productInMemoryRepository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductQuery request
                                                                , CancellationToken cancellationToken)
        {
            var products = await _productInMemoryRepository.GetAll();

            return products.Select(product => new ProductResponse()
            {
                Id = Guid.Parse(product.Id),
                Name = product.Name,
                Price = product.Price
            });
        }
    }
}
