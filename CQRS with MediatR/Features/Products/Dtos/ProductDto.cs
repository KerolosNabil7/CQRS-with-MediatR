namespace CQRS_with_MediatR.Features.Products.Dtos
{
    public record ProductDto(Guid Id, string Name, string Description, decimal Price);
}
