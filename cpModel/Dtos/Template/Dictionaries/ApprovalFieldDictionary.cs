
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request
    /// </summary>
    public class ApprovalFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Approval;

        public ApprovalFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetApprovalRequestTemplateFields();
        }

        public static List<TemplateField> GetApprovalRequestTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Approval_No", "ApprovalNo"));
            lstFields.Add(new TemplateField("Action_Date", "ActionDateString"));
            lstFields.Add(new TemplateField("Request_By", "RequestByName"));
            lstFields.Add(new TemplateField("Created_Date", "RequestDateString"));
            lstFields.Add(new TemplateField("Priority", "PriorityString"));
            lstFields.Add(new TemplateField("Subject", "SubjectPlainText"));
            lstFields.Add(new TemplateField("Body", "BodyHtmlNoDoc"));
            var aTo = new TemplateField("Addressees", "ApprovalTos");
            aTo.AddSubField(new TemplateField("To_Name", "FirstLast"));
            aTo.AddSubField(new TemplateField("To_Name_and_company", "FirstLastCompany"));
            aTo.AddSubField(new TemplateField("To_Company", "Company"));
            lstFields.Add(aTo);
            var acc = new TemplateField("CCs", "ApprovalCcs");
            acc.AddSubField(new TemplateField("CC_Name", "FirstLast"));
            acc.AddSubField(new TemplateField("CC_Name_and_company", "FirstLastCompany"));
            acc.AddSubField(new TemplateField("CC_Company", "Company"));
            lstFields.Add(acc);
            lstFields.Add(new TemplateField("Approval_No_With_Link", "ApprovalLink"));
            lstFields.Add(new TemplateField("Approval_Link_AsURL", "ApprovalLinkSiteURL"));


            return lstFields;
        }
    }
}
