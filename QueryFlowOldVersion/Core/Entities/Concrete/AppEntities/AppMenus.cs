using Core.Entities.Abstract;
using Entities.Concrete.AppEntities;
using System.Diagnostics.Contracts;

namespace Core.Entities.Concrete.AppEntities
{
    public class AppMenus : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>

        public int? RootId { get; set; } 
        public int MenuOrderNumber { get; set; }
        public string MenuName {  get; set; }
        public string MenuDescription { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameter {  get; set; }
        public string MenuIcon { get; set; }
        public bool IsNewTab { get; set; }
        public int ClaimId { get; set; }

        #region Navigation Property
        public AppClaim AppClaim { get; set; }  
        public List<AppMenus> ChildMenus { get; set; }  
        #endregion

    }
}
