using Dtos.Concrete.Categories;
using FluentValidation;

namespace Services.Concrete.ValidationRules
{
    public class CreateCategoryDtoRule : AbstractValidator<CreateCategoriesDto>
    {
        public CreateCategoryDtoRule()
        {
        }
    }
}
