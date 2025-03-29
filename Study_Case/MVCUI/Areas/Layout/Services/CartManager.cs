using Core.Utilities.Cookie;
using Entities.Concrete;
using MVCUI.Areas.Layout.Models;
using Newtonsoft.Json;

namespace MVCUI.Areas.Layout.Services
{
    public class CartManager
    {
        private readonly CookieManager _cookieManager;
        private const string CartCookieKey = "Cart";

        public CartManager(CookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }

        private List<CartItem> GetCart()
        {
            var json = _cookieManager.Get(CartCookieKey);
            return string.IsNullOrEmpty(json)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(json);
        }

        private void SaveCart(List<CartItem> cart)
        {
            var json = JsonConvert.SerializeObject(cart);
            _cookieManager.Create(CartCookieKey, json, 60); // 60 dakika çerez süresi
        }

        public void AddToCart(CartItem item)
        {
            var cart = GetCart();
            var existing = cart.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.ProductPrice = item.ProductPrice;
                existing.Quantity += item.Quantity;
                existing.TotalLinePrice = existing.Quantity * existing.ProductPrice;
            }
            else
            {
                cart.Add(item);
            }

            SaveCart(cart);
        }

        public void UpdateCartItem(int productId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Id == productId);
            if (item != null)
            {
                item.Quantity = quantity;
                item.TotalLinePrice = quantity * item.ProductPrice;
                SaveCart(cart);
            }
        }
        public void UpdateCartItemBulkInsert(List<CartItemUpdateDto> cartItems)
        {
            var cart = GetCart();
            foreach (var itemCardItems in cartItems)
            {
                var item = cart.FirstOrDefault(x => x.Id == itemCardItems.ProductId);
                if (item != null)
                {
                    item.Quantity = itemCardItems.Quantity;
                    item.TotalLinePrice = itemCardItems.Quantity * item.ProductPrice;
                }
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var itemToRemove = cart.FirstOrDefault(x => x.Id == productId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCart(cart);
            }
        }

        public List<CartItem> GetAllItems()
        {
            return GetCart();
        }

        public void ClearCart()
        {
            _cookieManager.Remove(CartCookieKey);
        }

    }
}
