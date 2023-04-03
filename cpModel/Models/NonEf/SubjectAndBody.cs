
namespace cpModel.Models.NonEf
{
    public class SubjectAndBody
    {
        public string SubjectHtml { get; set; }
        public string BodyHtml { get; set; }

        public SubjectAndBody(string subjectHtml, string bodyHtml)
        {
            SubjectHtml = subjectHtml;
            BodyHtml = bodyHtml;
        }
    }
}
