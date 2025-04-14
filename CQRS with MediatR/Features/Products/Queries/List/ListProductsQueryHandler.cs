using CQRS_with_MediatR.Features.Products.Dtos;
using CQRS_with_MediatR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_with_MediatR.Features.Products.Queries.List
{
    //Also, all the handlers would implement the IRequestHandler<T, R> where T is the incoming request (which in our case would be the Query itself), and R would be the response, which is a list of products.
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;
        public ListProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price)).ToListAsync();
            return products;
        }
    }
}
