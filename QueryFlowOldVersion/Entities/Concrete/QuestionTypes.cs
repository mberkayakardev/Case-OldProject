using Core.Entities.Abstract;

namespace Entities.Concrete
{
    /// <summary>
    ///  Soru tiplerimiz nelerdir ? 
    ///  
    /// 1. Evet / Hayır
    /// 
    /// 2. Çoktan Seçmeli ( A , B , C, D)
    /// 
    /// 3. Çoklu Seçim
    /// 
    /// 4. Klasik Soru 
    /// </summary>
    public class QuestionTypes : BaseEntity
    {
        public string QuestionTypeName { get; set; }
        public string QuestionTypeDescription { get; set; }

        #region Navigation Property

        public List<SurveyQuestions> SurveyQuestions { get; set; }
        #endregion
    }
}
