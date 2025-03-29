using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace Entities.Concrete
{
    public class Basket : BaseEntity
    {
        public int AppUserId { get; set; }
        public decimal TotalPrice { get; set; }

        #region Navigation Property
        public List<BasketDetail>  BasketDetails { get; set; }
        public AppUser AppUser { get; set; }

        #endregion

    }
}
