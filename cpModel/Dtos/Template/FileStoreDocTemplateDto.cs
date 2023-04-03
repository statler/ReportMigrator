namespace cpModel.Dtos.Template
{
    public class FileStoreDocTemplateDto : FileStoreDocDto
    {
        public string FileDateAsString => FileDate == null ? "" : FileDate.Value.ToShortDateString();
        public string FsNoInclDesc => $"{FilestoreDocNo}: {Description}";
    }
}
