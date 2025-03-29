using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Products : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice {  get; set; }

        public int Stock { get; set; }
        public int CategoryId { get; set; }

        #region Navigation Property
        public Categories Category { get; set; }
        public BasketDetail BasketDetail { get; set; }
        #endregion





    }
}
