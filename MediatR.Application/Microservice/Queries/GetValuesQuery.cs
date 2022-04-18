using MediatR;
using MediatRPattern.Entities;

namespace MediatRPattern.Queries
{
    public class GetValuesQuery
    {
        public record GetProductsQuery() : IRequest<IEnumerable<Product>>;


    }
}
