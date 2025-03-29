namespace Services.Concrete.message
{
    public static class Messages
    {
        public static class User
        {
            public const string BosBilgileriHatali = "Kullanıcı Adı veya Şifre boş geçilemez"; 
            public const string GirisBilgileriHatali = "Kullanıcı Adı veya Şifre Hatalıdır"; 
            public const string KullaniciKilitli = "Kullanici Hesabi Kilitlenmiştir. "; 
        }

        public static class Category
        {
            public const string ValidatonError = "Kategori oluşturulamadı. Birtakım hatalar mevcuttur";
            public const string Created = "Kategori Oluşturuldu";
            public const string Updated = "Kategori Güncellendi";
        }
        public static class BasketMessages
        {
            public const string AddedBasket = "Ürün Sepete Eklendi ";
        }



    }
}

