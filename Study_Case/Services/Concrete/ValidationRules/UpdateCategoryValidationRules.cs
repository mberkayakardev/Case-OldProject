using Dtos.Concrete.Categories;
using FluentValidation;

namespace Services.Concrete.ValidationRules
{
    public class UpdateCategoryValidationRules : AbstractValidator<UpdateCategoriesDto>
    {
        public UpdateCategoryValidationRules()
        {

        }
    }
}
