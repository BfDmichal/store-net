using AquaStoreAPI.Dtos;
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
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecificationParams specParams)
        {
            var spec = new ProductsWithCategoriesSpecification(specParams);
            var count = new ProductWithFiltersForCountSpecification(specParams);
            var totalItems = await _productRepository.CountAsync(count);
            var products = await _productRepository.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(specParams.PageIndex, specParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var spec = new ProductsWithCategoriesSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Product, ProductDto>(product));
        }
    }
}
