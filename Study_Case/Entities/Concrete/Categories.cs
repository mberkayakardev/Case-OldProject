using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Categories : BaseEntity
    {
        public string CategoryName { get; set; }    
        public string CategoryDescription { get; set; }

        #region Navigataion Property
        public List<Products> ProductList { get; set; }
        #endregion
    }
}
