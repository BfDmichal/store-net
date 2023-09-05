using AquaStoreAPI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AquaStoreAPI.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoriesController(IGenericRepository<ProductCategory> productCategoryRepository,IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryDto>> GetById([FromRoute]int id) 
        { 
            var category = await _productCategoryRepository.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductCategory, ProductCategoryDto>(category));
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductCategoryDto>>> GetAll()
        {
            var categories = await _productCategoryRepository.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<ProductCategory>, IReadOnlyList<ProductCategoryDto>>(categories));
        }
    }
}
