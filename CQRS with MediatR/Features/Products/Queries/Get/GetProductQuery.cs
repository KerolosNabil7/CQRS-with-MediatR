using CQRS_with_MediatR.Features.Products.Dtos;
using MediatR;

namespace CQRS_with_MediatR.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
}
