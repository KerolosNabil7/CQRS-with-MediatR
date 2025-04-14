using CQRS_with_MediatR.Domain;
using CQRS_with_MediatR.Persistence;
using MediatR;

namespace CQRS_with_MediatR.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly AppDbContext _context;
        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price);
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
