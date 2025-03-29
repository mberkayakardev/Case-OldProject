using Core.Dtos.Abstract;

namespace Dtos.Concrete.Categories
{
    public class CreateCategoriesDto : BaseDtos
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
