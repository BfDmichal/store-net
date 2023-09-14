using Application.Dtos;
using Application.Services;
using AquaStoreAPI.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AquaStoreAPI.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductsController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            this._productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecificationParams specParams)
        {
            var result = await _productService.GetProducts(specParams);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var result = await _productService.GetProduct(id);
            return Ok(result);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategoryDto>>> GetProductCategories()
        {
            return Ok(await _productCategoryService.GetProductCategories());
        }
    }
}
