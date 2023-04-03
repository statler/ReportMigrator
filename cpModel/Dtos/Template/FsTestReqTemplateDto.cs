using System;
using System.IO;

namespace cpModel.Dtos.Template
{
    public class FsTestReqTemplateDto : FsTestReqDto, IFilestoreDocsBase
    {
        public string FileDateAsString => FileDate == null ? "" : FileDate.Value.ToShortDateString();
    }
}
