using AquaStoreAPI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductsWithCategoriesSpecification();
            var products = await _productRepository.GetAllWithSpecAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
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
