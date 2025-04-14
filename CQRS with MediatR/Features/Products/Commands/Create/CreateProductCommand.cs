using MediatR;

namespace CQRS_with_MediatR.Features.Products.Commands.Create
{
    public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>;
}
