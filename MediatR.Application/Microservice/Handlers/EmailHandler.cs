using MediatR;
using MediatR.Application.Interfaces;
using static MediatRPattern.Notifications.ProductNotification;

namespace MediatRPattern.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public EmailHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Email sent");
            await Task.CompletedTask;
        }
    }
}
