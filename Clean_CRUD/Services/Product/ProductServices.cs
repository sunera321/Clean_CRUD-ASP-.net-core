using AutoMapper;
using Clean_CRUD.Data;
using Clean_CRUD.Exceptions;
using Clean_CRUD.Models.DTOs;
using Clean_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Clean_CRUD.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
     
        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw NotFoundException.Create<Models.Product>(id);
            }
            return _mapper.Map<ProductDto>(product);

        }
        public async Task<ProductDto> CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Models.Product>(createProductDto);
            product.CreatedAt = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }
        public async Task<ProductDto> UpdateProduct(int id,CreateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw NotFoundException.Create<Models.Product>(id);
            }
            _mapper.Map(updateProductDto, product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<ProductDto> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw NotFoundException.Create<Models.Product>(id);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

      
    }
}
