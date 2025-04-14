using CQRS_with_MediatR.Persistence;
using MediatR;

namespace CQRS_with_MediatR.Features.Products.Commands.Delete
{
    //Note: We didn't return the deleted object(product) so that there is no return type in IRequestHandler

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly AppDbContext _context;
        public DeleteProductCommandHandler(AppDbContext _context)
        {
            _context = _context;
        }
        public async Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(command.Id);
            if (product == null)
                return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
