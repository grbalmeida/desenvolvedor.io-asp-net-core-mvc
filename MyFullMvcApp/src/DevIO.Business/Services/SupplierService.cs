using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;

        public SupplierService(
            ISupplierRepository supplierRepository,
            IAddressRepository addressRepository,
            INotifier notifier) : base(notifier)
        {
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)
                || !PerformValidation(new AddressValidation(), supplier.Address)) return;

            if (_supplierRepository.Search(s => s.Document == supplier.Document).Result.Any())
            {
                Notify("There is already a supplier with this document entered.");
                return;
            }

            await _supplierRepository.Add(supplier);

            return;
        }

        public async Task Update(Supplier supplier)
        {
            if (!PerformValidation(new SupplierValidation(), supplier)) return;
        
            if (_supplierRepository.Search(s => s.Document == supplier.Document && s.Id != supplier.Id).Result.Any())
            {
                Notify("There is already a supplier with this document entered.");
                return;
            }

            await _supplierRepository.Update(supplier);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!PerformValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task Remove(Guid id)
        {
            if (_supplierRepository.GetAddressAndProductsFromSupplier(id).Result.Products.Any())
            {
                Notify("The supplier has registered products!");
                return;
            }

            await _supplierRepository.Remove(id);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}
