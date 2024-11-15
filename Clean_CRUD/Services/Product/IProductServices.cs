using Clean_CRUD.Models.DTOs;

namespace Clean_CRUD.Services.Product
{
    public interface IProductServices
    {
        //add interface realated ProductServices

        Task<List<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateProduct(CreateProductDto createProductDto);
        Task<ProductDto> UpdateProduct(int id, CreateProductDto updateProductDto);
        Task<ProductDto> DeleteProduct(int id);





    }
}
