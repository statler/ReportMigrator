using System;

namespace cpModel.Dtos.Lookup
{
    public class FileStoreDocLookupDto
    {
        public int FileStoreDocId { get; set; }
        public int? FilestoreDocNo { get; set; }
        public string Description { get; set; }
        public DateTime? FileDate { get; set; }
    }
}
