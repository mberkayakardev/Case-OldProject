using System.Xml;

namespace WebApplication1.Models
{
    public class context
    {
        public static List<MenuItem> menuItems = new List<MenuItem>
        {
             new MenuItem {Id = 1, Title = "1. Menu ", Url = "", ParentId = null, SubItems = null },
             new MenuItem {Id = 2, Title = "2. Menu ", Url = "", ParentId = 1, SubItems = null },
             new MenuItem {Id = 3, Title = "3. Menu ", Url = "", ParentId = 2, SubItems = null },
             new MenuItem {Id = 4, Title = "4. Menu ", Url = "", ParentId = null, SubItems = null },
             new MenuItem {Id = 5, Title = "5. Menu ", Url = "", ParentId = 4, SubItems = null },
             new MenuItem {Id = 6, Title = "6. Menu ", Url = "", ParentId = null, SubItems = null },
             new MenuItem {Id = 7, Title = "7. Menu ", Url = "", ParentId = null, SubItems = null },
             new MenuItem {Id = 8, Title = "8. Menu ", Url = "", ParentId = 7, SubItems = null },
             new MenuItem {Id = 9, Title = "9. Menu ", Url = "", ParentId = 8, SubItems = null },


        };
    }
}
