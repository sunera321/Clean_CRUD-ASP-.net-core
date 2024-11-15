using AutoMapper;
using Clean_CRUD.Models;
using Clean_CRUD.Models.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clean_CRUD.Mappings
{
    public class MappingProfile : Profile
    {
       public MappingProfile() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
        }


    }
}
