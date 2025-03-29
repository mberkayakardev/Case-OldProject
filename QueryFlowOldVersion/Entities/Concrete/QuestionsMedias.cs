using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class QuestionsMedias : BaseEntity
    {
        public int QuestionId { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public string DocumentType { get; set; }
        public int OrderNumber { get; set; }

    }
}
