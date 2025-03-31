namespace WebApplication1.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; } // Nullable, çünkü kök menü öğelerinin ParentId'si olmayacak
        public List<MenuItem> SubItems { get; set; } // Alt menü öğeleri
    }
}
