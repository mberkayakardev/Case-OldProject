using Core.Dtos.Abstract;

namespace Dtos.Concrete.Categories
{
    public class UpdateCategoriesDto : BaseUpdateDtos
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
