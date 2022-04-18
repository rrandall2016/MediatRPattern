using MediatR;
using MediatR.Application.Interfaces;
using MediatRPattern.Commands;
using MediatRPattern.Entities;

using static MediatRPattern.Commands.AddSingleProductCommand;

namespace MediatRPattern.Handlers
{
    //Unit is same as void
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
        
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           await _fakeDataStore.AddProduct(request.product);
            return request.product;
          
        }
    }
}
