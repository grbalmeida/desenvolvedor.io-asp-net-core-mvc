﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using DevIO.Business.Models;

namespace DevIO.App.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository,
            ISupplierService supplierService,
            IMapper mapper,
            INotifier notifier) : base(notifier)
        {
            _supplierRepository = supplierRepository;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [Route("supplier-list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }

        [Route("supplier-data/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null) return NotFound();

            return View(supplierViewModel);
        }

        [Route("new-supplier")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("new-supplier")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierService.Add(supplier);

            if (!ValidOperation()) return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("edit-supplier/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetAddressAndProductsFromSupplier(id);

            if (supplierViewModel == null) return NotFound();

            return View(supplierViewModel);
        }

        [Route("edit-supplier/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierService.Update(supplier);

            if (!ValidOperation()) return View(await GetAddressAndProductsFromSupplier(id));

            return RedirectToAction(nameof(Index));
        }

        [Route("delete-supplier/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null) return NotFound();

            return View(supplierViewModel);
        }

        [Route("delete-supplier/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplier = await GetSupplierAddress(id);

            if (supplier == null) return NotFound();

            await _supplierService.Remove(id);

            if (!ValidOperation()) return View(supplier);

            return RedirectToAction(nameof(Index));
        }

        [Route("get-supplier-address/{id:guid}")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var supplier = await GetSupplierAddress(id);

            if (supplier == null) return NotFound();

            return PartialView("_AddressDetails", supplier);
        }

        [Route("update-supplier-address/{id:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            var supplier = await GetSupplierAddress(id);

            if (supplier == null) return NotFound();

            return PartialView("_UpdateAddress", new SupplierViewModel { Address = supplier.Address });
        }

        [Route("update-supplier-address/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(SupplierViewModel supplierViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Document");

            if (!ModelState.IsValid) return PartialView("_UpdateAddress", supplierViewModel);

            await _supplierService.UpdateAddress(_mapper.Map<Address>(supplierViewModel.Address));

            if (!ValidOperation()) return PartialView("_UpdateAddress", supplierViewModel);

            var url = Url.Action("GetAddress", "Suppliers", new { id = supplierViewModel.Address.SupplierId });

            return Json(new { success = true, url });
        }

        private async Task<SupplierViewModel> GetSupplierAddress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierAddress(id));
        }

        private async Task<SupplierViewModel> GetAddressAndProductsFromSupplier(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetAddressAndProductsFromSupplier(id));
        }
    }
}
