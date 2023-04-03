using cpModel.Enums;
using cpModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Template
{
    public class TestRequestTemplateDto : TestRequestWithGeometryDto
    {
        public string ProjectNumber { get; set; }

        public string ProjectName { get; set; }
        public string DateRaisedString => DateRequest == null ? "" : DateRequest.Value.ToShortDateString();
        public string DateRequiredString => DateRequired == null ? "" : DateRequired.Value.ToShortDateString();
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Test_Request_Notification, TestRequestId);

        public string TestReqLink => $@"<a href='{URL}'>{TestRequestNo}</a>";
        public string TestReqLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";

        public ICollection<FileStoreDocDto> FilestoreDocsOrdered { get; set; }
        public ICollection<TestRequestTestDto> TestsOrdered { get; set; }

        public string TestInfoString
        {
            get
            {
                List<string> lstTestList = new List<string>();
                var tstGrouped = TestsOrdered.GroupBy(x => x.TestMethodName);
                foreach (var g in tstGrouped)
                {
                    lstTestList.Add($"{g.Count()} x {g.Key}");
                }
                return string.Join(Environment.NewLine, lstTestList);
            }
        }
    }

}
