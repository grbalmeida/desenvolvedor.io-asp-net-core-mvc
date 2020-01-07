using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Guid id);
    }
}
