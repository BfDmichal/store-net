using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductCategoryService 
    {
        Task<IReadOnlyList<ProductCategoryDto>> GetProductCategories();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IGenericRepository<ProductCategory> _repository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IGenericRepository<ProductCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductCategoryDto>> GetProductCategories()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<ProductCategory>, IReadOnlyList<ProductCategoryDto>>(categories);
        }
    }
}
