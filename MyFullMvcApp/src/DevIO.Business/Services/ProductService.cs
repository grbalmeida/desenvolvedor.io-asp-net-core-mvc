using System;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        public async Task Add(Product product)
        {
            if (!PerformValidation(new ProductValidation(), product)) return;
        }

        public async Task Update(Product product)
        {
            if (!PerformValidation(new ProductValidation(), product)) return;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
