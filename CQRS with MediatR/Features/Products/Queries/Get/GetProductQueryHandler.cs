using CQRS_with_MediatR.Features.Products.Dtos;
using CQRS_with_MediatR.Persistence;
using MediatR;

namespace CQRS_with_MediatR.Features.Products.Queries.Get
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto?>
    {
        private readonly AppDbContext _context;
        public GetProductQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return null;
            }
            return new ProductDto(product.Id, product.Name, product.Description, product.Price);
        }
    }
}
