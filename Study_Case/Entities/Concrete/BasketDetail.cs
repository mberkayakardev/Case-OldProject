using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace Entities.Concrete
{
    public class BasketDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public int BasketId { get; set; }

        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        
        #region Navigation Property
        public Basket Basket { get; set; }
        public Products Products { get; set; }
        #endregion

    }
}
