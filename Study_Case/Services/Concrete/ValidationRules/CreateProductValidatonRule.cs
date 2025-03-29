using Dtos.Concrete.Products;
using FluentValidation;

namespace Services.Concrete.ValidationRules
{
    public class CreateProductValidatonRule : AbstractValidator<CreateProductsDto>
    {
        public CreateProductValidatonRule()
        {
            //RuleFor()
        }
    }
}
