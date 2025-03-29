using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class SurveyCards : BaseEntity
    {
        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }
        
        public int? AppRoverId { get; set; } /// Onaycı Mekanizması için 

        #region Navigation Property
        public List<SurveyQuestions> SurveyQuestions { get; set; }  
        public List<SurveysForUser> SurveysForUsers { get; set; }

        #endregion
    }
}
