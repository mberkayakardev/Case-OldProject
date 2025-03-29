using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using FluentValidation;

namespace Services.Concrete.ValidationRules
{
    public class UpdateProductRule : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductRule()
        {
            // CreateMap();
        }
    }
}
