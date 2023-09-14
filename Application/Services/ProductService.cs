using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Core.Specifications;

namespace Application.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int id);
        Task<Pagination<ProductDto>> GetProducts(ProductSpecificationParams specParams);
    }
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductDto>> GetProducts(ProductSpecificationParams specParams)
        {
            var spec = new ProductsWithCategoriesSpecification(specParams);
            var count = new ProductWithFiltersForCountSpecification(specParams);
            var totalItems = await _productRepository.CountAsync(count);
            var products = await _productRepository.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return new Pagination<ProductDto>(specParams.PageIndex, specParams.PageSize, totalItems, data);
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var spec = new ProductsWithCategoriesSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}