using MediatRPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Application.Interfaces
{
    public interface FakeDataStore
    {
        public static List<Product> _products;

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<Product> GetProductById(int id)
        {
            return await Task.FromResult(_products.First(item => item.Id == id));

        }
        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
