using MediatR;
using MediatRPattern.Entities;

namespace MediatRPattern.Commands
{
    public class AddSingleProductCommand
    {
        public record AddProductCommand(Product product) : IRequest<Product>;
    }
}
