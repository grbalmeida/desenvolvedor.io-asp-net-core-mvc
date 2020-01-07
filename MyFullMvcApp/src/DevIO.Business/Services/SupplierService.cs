using System;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public async Task Add(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)
                || !PerformValidation(new AddressValidation(), supplier.Address)) return;

            return;
        }

        public async Task Update(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)) return;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!PerformValidation(new AddressValidation(), address)) return;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
