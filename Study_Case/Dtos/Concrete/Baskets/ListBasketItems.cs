using Core.Dtos.Abstract;

namespace Dtos.Concrete.Baskets
{
    public class ListBasketItems : BaseDtos
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCardImage { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalLinePrice { get; set; }
    }
}
