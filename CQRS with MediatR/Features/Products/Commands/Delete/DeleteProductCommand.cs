using MediatR;

namespace CQRS_with_MediatR.Features.Products.Commands.Delete
{
    //Note: We didn't return the deleted object(product) so that there is no return type in IRequest
    public record DeleteProductCommand(Guid Id) : IRequest;
}
