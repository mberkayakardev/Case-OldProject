using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class QuestionAnswers : BaseEntity
    {
        public int QuestionsId { get; set; }

        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public int QuestionTypeId { get; set; }
        public int QuestionPoint { get; set; } /// çoklu seçimler için birden fazla cevap olacağından ötürü her cevabın değeri yada çoktan seçimliler için tek cevap değeri 
        public int Order {  get; set; }
        public bool IsTrue { get; set; }
        
        #region Navigation Property

        public List<SurveyQuestions> SurveyQuestions  { get; set; }
        public QuestionTypes QuestionTypes { get; set; }    
        #endregion
    }
}
