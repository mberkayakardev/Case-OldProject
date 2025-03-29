using AutoMapper;
using Dtos.Concrete.Categories;
using Entities.Concrete;

namespace Services.Concrete.MappingProfiles
{
    public class CategoriesMappingProfiles: Profile
    {
        public CategoriesMappingProfiles()
        {
            CreateMap<ListCategoriesDto, Categories>().ReverseMap();
            CreateMap<CreateCategoriesDto, Categories>().ReverseMap();
            CreateMap<UpdateCategoriesDto, Categories>().ReverseMap();


        }
    }
}
