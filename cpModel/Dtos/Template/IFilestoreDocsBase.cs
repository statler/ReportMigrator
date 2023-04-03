using System;

namespace cpModel.Dtos.Template
{
    public interface IFilestoreDocsBase
    {
        string Extension { get; }
        DateTime? FileDate { get; set; }
        string FileDateAsString { get; }
        string FileDesc { get; set; }
        string Filename { get; set; }
        string FsDescription { get; }
        int? FsNo { get; set; }
    }
}
