using System;

namespace Application.Requests
{
    public class CreateProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
