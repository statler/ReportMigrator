
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request response
    /// </summary>
    public class CnResponseFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Contract_Notice_Response;

        public CnResponseFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetNoticeResponseTemplateFields();
        }

        public static List<TemplateField> GetNoticeResponseTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Response_ID", "CnResponseId"));
            lstFields.Add(new TemplateField("Response_Text", "ResponseHtmlNoDoc"));
            lstFields.Add(new TemplateField("Response_By", "ResponseByName"));
            lstFields.Add(new TemplateField("Response_Date", "ResponseDateString"));
            lstFields.Add(new TemplateField("Action_Reqd_By", "ActionRequiredByName"));
            lstFields.Add(new TemplateField("Action_Reqd_Date", "ActionRequiredDateString"));
            lstFields.Add(new TemplateField("Contract_Notice_Reference", "ContractNoticeReference"));
            lstFields.Add(new TemplateField("Contract_Notice_Subject", "ContractNoticeSubjectHtml"));
            lstFields.Add(new TemplateField("Notice_Ref_With_Link", "NoticeLink"));
            lstFields.Add(new TemplateField("Notice_Link_AsURL", "NoticeLinkSiteURL"));

            return lstFields;


        }
    }
}
