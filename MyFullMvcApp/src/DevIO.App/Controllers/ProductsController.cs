﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using DevIO.App.Extensions;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            IProductService productService,
            IMapper mapper,
            INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("product-list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsAndSuppliers()));
        }

        [AllowAnonymous]
        [Route("product-data/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            return View(productViewModel);
        }

        [ClaimsAuthorize("Product", "Add")]
        [Route("new-product")]
        public async Task<IActionResult> Create()
        {
            var productViewModel = await PopulateSuppliers(new ProductViewModel());
            
            return View(productViewModel);
        }

        [ClaimsAuthorize("Product", "Add")]
        [Route("new-product")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await PopulateSuppliers(productViewModel);

            if (!ModelState.IsValid) return View(productViewModel);

            var imagePrefix = Guid.NewGuid() + "_";

            productViewModel.Image = imagePrefix + productViewModel.UploadImage.FileName;

            if (!await UploadFile(productViewModel.UploadImage, imagePrefix))
            {
                return View(productViewModel);
            }

            await _productService.Add(_mapper.Map<Product>(productViewModel));

            if (!ValidOperation()) return View(productViewModel);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Product", "Edit")]
        [Route("edit-product/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            return View(productViewModel);
        }

        [ClaimsAuthorize("Product", "Edit")]
        [Route("edit-product/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            var productUpdate = await GetProduct(id);
            productViewModel.Supplier = productUpdate.Supplier;
            productViewModel.Image = productUpdate.Image;

            if (!ModelState.IsValid) return View(productViewModel);
            
            if (productViewModel.UploadImage != null)
            {
                var imagePrefix = Guid.NewGuid() + "_";

                if (!await UploadFile(productViewModel.UploadImage, imagePrefix))
                {
                    return View(productViewModel);
                }

                productUpdate.Image = imagePrefix + productViewModel.UploadImage.FileName;
            }

            productUpdate.Name = productViewModel.Name;
            productUpdate.Description = productViewModel.Description;
            productUpdate.Price = productViewModel.Price;
            productUpdate.Active = productViewModel.Active;

            await _productService.Update(_mapper.Map<Product>(productUpdate));

            if (!ValidOperation()) return View(productViewModel);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Product", "Delete")]
        [Route("delete-product/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [ClaimsAuthorize("Product", "Delete")]
        [Route("delete-product/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            await _productService.Remove(id);

            if (!ValidOperation()) return View(product);

            TempData["Success"] = "Product successfully deleted!";

            return RedirectToAction(nameof(Index));
        }

        [Route("get-product/{id:guid}")]
        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductAndSupplier(id));
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
            return product;
        }

        private async Task<ProductViewModel> PopulateSuppliers(ProductViewModel productViewModel)
        {
            productViewModel.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
            return productViewModel;
        }

        private async Task<bool> UploadFile(IFormFile file, string imagePrefix)
        {
            if (file.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product-images", imagePrefix + file.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "A file with this name already exists!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
