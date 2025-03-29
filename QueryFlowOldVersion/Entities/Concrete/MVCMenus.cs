using Core.Entities.Concrete.AppEntities;

namespace Entities.Concrete
{
    public class MVCMenus : AppMenus
    {
        public int? ParentId {  get; set; }
        public int OrderNumber { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string OptionalParameter {  get; set; }
        public string IconName { get; set; }
        public bool IsNewTab { get; set; }

    }
}
