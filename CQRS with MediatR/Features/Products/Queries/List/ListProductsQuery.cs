using CQRS_with_MediatR.Features.Products.Dtos;
using MediatR;

namespace CQRS_with_MediatR.Features.Products.Queries.List
{
    //Every Query / Command object would inherit from IRequest<T> interface of the MediatR library, where T is the object to be returned.
    //so it will be IRequest< List<ProductDto> >
    public record ListProductsQuery : IRequest<List<ProductDto>>;
}
