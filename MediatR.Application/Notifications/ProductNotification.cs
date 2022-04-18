using MediatR;
using MediatRPattern.Entities;

namespace MediatRPattern.Notifications
{
    public class ProductNotification
    {
        public record ProductAddedNotification(Product product) : INotification;
    }
}
