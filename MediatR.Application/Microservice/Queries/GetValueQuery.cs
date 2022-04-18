using MediatR;
using MediatRPattern.Entities;

namespace MediatRPattern.Queries
{
    public class GetValueQuery
    {
        public record GetProductByIdQuery(int id) : IRequest<Product>;

    }
}
