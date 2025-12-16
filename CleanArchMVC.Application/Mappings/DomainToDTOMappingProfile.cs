using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductCreateCommand, ProductDTO>().ReverseMap();
            CreateMap<ProductUpdateCommand, ProductDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
