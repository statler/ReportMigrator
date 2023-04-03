
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    public class ApprovalNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Approval_Notification;

        public ApprovalNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSet<ApprovalsSetTemplateDto>("Approvals", "Approvals", GetApprovalForNotificationTemplateFields);
        }

        private static List<TemplateField> GetApprovalForNotificationTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Approval_No", "ApprovalNo"));
            lstFields.Add(new TemplateField("Request_Date", "RequestDateString"));
            lstFields.Add(new TemplateField("Publish_Date", "PublishDateString"));
            lstFields.Add(new TemplateField("Last_Status_Date", "DateLastStatusString"));
            lstFields.Add(new TemplateField("Action_Reqd_Date", "ActionDateString"));
            lstFields.Add(new TemplateField("Request_By", "RequestByName"));
            lstFields.Add(new TemplateField("Priority", "PriorityString"));
            lstFields.Add(new TemplateField("Created_Date", "RequestDateString"));
            lstFields.Add(new TemplateField("Subject", "SubjectPlainText"));
            lstFields.Add(new TemplateField("Addressees", "ApprovalToCSV"));
            lstFields.Add(new TemplateField("Category", "ApprovalCategoryName"));
            lstFields.Add(new TemplateField("Last_Action_By", "LastActionByName"));
            lstFields.Add(new TemplateField("Days_until_due", "DaysTilDue"));
            lstFields.Add(new TemplateField("Status", "Status"));

            lstFields.Add(new TemplateField("Approval_No_With_Link", "ApprovalLink"));
            lstFields.Add(new TemplateField("Approval_Link_AsURL", "ApprovalLinkSiteURL"));

            return lstFields;
        }
    }
}
