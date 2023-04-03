namespace cpModel.Dtos
{
    public class EmailLogDto : EmailLogListDto
    {
        public string Content { get; set; }
        public string AttachmentString { get; set; }
    }

}
