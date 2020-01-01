using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using MyFullMvcApp.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(MyDbContext context) : base(context) { }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.SupplierId == supplierId);
        }
    }
}
