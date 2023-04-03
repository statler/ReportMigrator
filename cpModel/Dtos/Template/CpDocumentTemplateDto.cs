using System;

namespace cpModel.Dtos.Template
{
    public class CpDocumentTemplateDto
    {
        public int DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public string DocGroup { get; set; }
        public string DocType { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string LastRevRef { get; set; }
        public DateTime? LastRevDate { get; set; }
        public string LastRevRefOrInitial => string.IsNullOrWhiteSpace(LastRevRef) ? "[No Revision]" : LastRevRef;
        public string LastRevDateOrInitialAsString => (LastRevDate ?? DocumentDate)?.ToShortDateString() ?? "";
        public string DocNoLastRevRefOrInitial => $"{DocumentNo} ({LastRevRefOrInitial})";
        public string DocNoLastRevDateOrInitial
        {
            get
            {
                if (string.IsNullOrEmpty(LastRevDateOrInitialAsString)) return $"{DocumentNo}";
                return $"{DocumentNo} ({LastRevDateOrInitialAsString})";
            }
        }
        public string DocNoAndDesc => $"{DocumentNo}: {Description}";
    }
}
