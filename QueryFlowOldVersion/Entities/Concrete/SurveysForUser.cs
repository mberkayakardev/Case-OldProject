using ApiService.Entities.Concrete.AppEntities;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class SurveysForUser : BaseEntity
    {
        public int UserId { get; set; }
        public int SurveysCard {  get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public bool IsSolved { get; set; }
        public int LastQuestionId { get; set; } // Son çözdüğü soru ıd sini tutuyoruz ki internet bağlantısı vs koparsa tekrar geri geldiğinde aynı sorundan devam edebilsin. 

        #region Navigation Property
        public AppUser AppUser { get; set; }
        public SurveyCards SurveyCards { get; set; }
        #endregion

    }
}   
