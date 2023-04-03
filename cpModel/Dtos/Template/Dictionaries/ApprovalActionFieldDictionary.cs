
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request
    /// </summary>
    public class ApprovalActionFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {

        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Approval_Action_Advice;

        public ApprovalActionFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetApprovalActionTemplateFields();
        }

        public List<TemplateField> GetApprovalActionTemplateFields()
        {
            List<TemplateField> lstFields = ApprovalFieldDictionary.GetApprovalRequestTemplateFields();
            lstFields.Add(new TemplateField("Current_Status", "Status"));
            lstFields.Add(new TemplateField("Date_Last_Status", "DateLastStatusString"));
            lstFields.Add(new TemplateField("Last_Action_By", "LastActionByName"));
            lstFields.Add(new TemplateField("Last_Action_Comment", "LastActionComment"));
            lstFields.Add(new TemplateField("Is_Complete", "IsCompleted"));
            lstFields.Add(new TemplateField("Is_Alert", "IsLatestStepAlert"));
            lstFields.Add(new TemplateField("Progress_Info", "ProgressString"));

            var awfl = new TemplateField("Workflow_Logs", "WorkflowLogsOrdered");
            awfl.AddSubField(new TemplateField("Log_by", "LogByName"));
            awfl.AddSubField(new TemplateField("Log_Date", "LogDateString"));
            awfl.AddSubField(new TemplateField("Action", "ActionName"));
            awfl.AddSubField(new TemplateField("Log_Comment", "LogCommentHtmlNoDoc"));
            lstFields.Add(awfl);
            return lstFields;

        }


    }
}
