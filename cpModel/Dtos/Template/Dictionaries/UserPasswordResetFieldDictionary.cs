
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request
    /// </summary>
    public class UserPasswordResetFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.User_Password_Reset;

        public UserPasswordResetFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetUserPasswordResetTemplateFields();
        }


        private static List<TemplateField> GetUserPasswordResetTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("User_Full_Name", "FullName"));
            lstFields.Add(new TemplateField("User_Email", "Email"));
            lstFields.Add(new TemplateField("Reset_Expiry", "DatePasswordRequestExpiresString"));
            lstFields.Add(new TemplateField("Password_Reset_Link_AsURL", "UserPasswordResetLinkSiteURL"));

            return lstFields;
        }

    }
}
