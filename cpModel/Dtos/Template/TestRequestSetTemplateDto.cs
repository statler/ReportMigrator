using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class TestRequestSetTemplateDto : TemplateSetBaseDto
    {
        //A wrapper for multiple test requests
        public List<TestRequestTemplateDto> TestRequests { get; set; }
        public List<FsTestReqTemplateDto> FilestoreDocsOrdered { get; set; }
    }
}
