using System;
using System.Collections.Generic;
using System.Text;
using cpModel.Enums;
using cpModel.Helpers;

namespace cpModel.Dtos.Template
{
    public class SurveyRequestTemplateDto : SurveyRequestDto
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string DateRequestString => DateRequest == null ? "" : DateRequest.Value.ToShortDateString();
        public string DateRequiredString => DateReqd == null ? "" : DateReqd.Value.ToShortDateString();
        public string URL => APIConstants.GetURLString(TemplateTypeEnum.Survey_Request_Notification, SurveyId);
        public string SurveyReqLink => $@"<a href='{URL}'>{SrNumber}</a>";
        public string SurveyReqLinkSiteURL => $@"<a href='{URL}'>{APIConstants.MobileSiteURL}</a>";
        public string SurveyTypeDesc => SurveyTypeId == null ? "" : Enum.GetName(typeof(SurveyTypeEnum), SurveyTypeId);
        public ICollection<LotSurveyDto> LotsOrdered { get; set; }
        public ICollection<ApprovalSurveyDto> Approvals { get; set; }
        public ICollection<SurveyResultSetDto> SurveyResultSets { get; set; }
        public ICollection<FileStoreDocDto> FilestoreDocsOrdered { get; set; }
        public string LotInfoString
        {
            get
            {
                List<string> lstLotList = new List<string>();
                foreach (var lot in LotsOrdered)
                {
                    lstLotList.Add($"{lot.LotNumber} {lot.LotDescription}");
                }
                return string.Join(Environment.NewLine, lstLotList);
            }
        }
        public string LotInfoCSVString
        {
            get
            {
                List<string> lstLotList = new List<string>();
                foreach (var lot in LotsOrdered)
                {
                    lstLotList.Add($"{lot.LotNumber}");
                }
                return string.Join(",", lstLotList);
            }
        }
        public string ApprovalInfoString
        {
            get
            {
                List<string> lstApprovalList = new List<string>();
                foreach (var apr in Approvals)
                {
                    lstApprovalList.Add($"{apr.ApprovalNo} {apr.ApprovalSubjectPlainText}");
                }
                return string.Join(Environment.NewLine, lstApprovalList);
            }
        }
    }
}
