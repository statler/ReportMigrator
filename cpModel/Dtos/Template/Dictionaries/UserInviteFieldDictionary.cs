
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request
    /// </summary>
    public class UserInviteFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.User_Invite;

        public UserInviteFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetUserInviteTemplateFields();
        }

        public static List<TemplateField> GetUserInviteTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
            lstFields.Add(new TemplateField("Addressee_Email", "EmailAddress"));
            lstFields.Add(new TemplateField("Expiry_Date", "ExpiryDateString"));
            lstFields.Add(new TemplateField("Requires_Paid_Subscription", "RequiresPaidSubscription"));
            lstFields.Add(new TemplateField("Registration_Link_AsURL", "RegistrationInviteLinkSiteURL"));
            lstFields.Add(new TemplateField("Invite_Link_AsURL", "UserInviteLinkSiteURL"));

            return lstFields;
        }

    }
}
