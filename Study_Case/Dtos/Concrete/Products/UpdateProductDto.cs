using Core.Dtos.Abstract;

namespace Dtos.Concrete.Products
{
    public class UpdateProductDto : BaseUpdateDtos
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
