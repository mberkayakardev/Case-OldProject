using Core.Dtos.Abstract;

namespace Dtos.Concrete.Categories
{
    public class ListCategoriesDto : BaseDtos
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public bool IsActive { get; set; }


    }
}
