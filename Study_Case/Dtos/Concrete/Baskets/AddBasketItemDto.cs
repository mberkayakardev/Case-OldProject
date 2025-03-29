using Core.Dtos.Abstract;

namespace Dtos.Concrete.Baskets
{
    public class AddBasketItemDto : BaseDtos
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
