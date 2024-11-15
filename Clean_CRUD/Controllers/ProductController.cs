using AutoMapper;
using Clean_CRUD.Exceptions;
using Clean_CRUD.Models.DTOs;
using Clean_CRUD.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductServices productService)
        {
            _productService = productService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null)
            {
                throw NotFoundException.Create<Models.Product>(id);
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var product = await _productService.CreateProduct(createProductDto);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CreateProductDto updateProductDto)
        {
            var product = await _productService.UpdateProduct(id, updateProductDto);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProduct(id);
            return Ok(product);
        }
    }
}
