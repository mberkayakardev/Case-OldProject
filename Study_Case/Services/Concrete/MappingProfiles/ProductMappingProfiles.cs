using AutoMapper;
using Dtos.Concrete.Products;
using Entities.Concrete;

namespace Services.Concrete.MappingProfiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<UpdateProductDto, Products>().ReverseMap();

            CreateMap<CreateProductsDto, Products>().ReverseMap();

            CreateMap<ListProductDto, Products>();
            CreateMap<Products, ListProductDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName ?? "" : ""))
                .ReverseMap();
        }
    }
}
