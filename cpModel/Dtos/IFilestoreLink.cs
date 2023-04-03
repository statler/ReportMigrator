namespace cpModel.Dtos
{
    public interface IFilestoreLink
    {
        int? FsId { get; set; }
        int? RelatedId { get; }

        string Filename { get; set; }
        string FileDesc { get; set; }
        string RelatedName { get; }

        string FsDescription { get; }

        string Extension { get; }
    }
}
