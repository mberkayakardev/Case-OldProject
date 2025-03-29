using Core.Entities.Abstract;
using System.Diagnostics.Contracts;

namespace Entities.Concrete
{
    public class SurveyQuestions :BaseEntity
    {
        public int SurveyId {  get; set; }
        public int OrderNumber { get; set; }
        public string QuestionText { get; set; }
        public bool AutomaticCalculation { get; set; } /// şöyle bir durum var bazı sorular otomatik olarak hesaplanabilir. evet hayır, çoktan seçmeli gibi. bu tarz sorularda otomatik hesaplama yapsın yada yönteticiye bıraksın tarzı düşünüldü 
        public int QuestionType { get; set; }
        public int QuestionPoints { get; set; } /// Genel soru puanı. Atıyorum çoklu seçimde 4 tane doğru cevap vardır soruların tanesi 2 puandır buraya 8 yazacaksın cevaplarda da maximum 8 olacak şekilde ayar yapacaksın. yada klasik bir sınav. o zaman sadece buraya sorunun kaç puan olduğunu yazacaksın

        #region Navigation Property

        public SurveyCards SurveyCard { get; set; }
        public QuestionTypes QuestionTypes { get; set; }
        
        public List<QuestionAnswers> QuestionAnswers { get; set; }
        #endregion
    }
}
