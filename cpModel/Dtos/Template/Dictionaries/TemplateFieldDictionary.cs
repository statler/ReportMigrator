using cpModel.Dtos.Template;
using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Template
{
    public static class TemplateFieldDictionary
    {
        public static Dictionary<string, TemplateField> GetTemplateFieldDictionary(TemplateTypeEnum? templateType)
        {
            Dictionary<string, TemplateField> dctTF = new Dictionary<string, TemplateField>();
            List<TemplateField> lstTemplateField = GetTemplateFieldList(templateType);
            AddFieldsToDict(dctTF, lstTemplateField);

            return dctTF;
        }

        public static List<TemplateField> GetTemplateFieldList_visible(TemplateTypeEnum? templateType)
        {
            return GetTemplateFieldList(templateType).Where(x => !x.shouldHide).ToList();
        }

        public static List<TemplateField> GetTemplateFieldList(TemplateTypeEnum? templateType)
        {
            FieldDictionaryBase _dct = GetFieldDictionary(templateType);

            return _dct == null ? new List<TemplateField>() : _dct.GetTemplateFields();
        }

        public static FieldDictionaryBase GetFieldDictionary(TemplateTypeEnum? templateType)
        {
            switch (templateType)
            {
                case null: 
                    return null;
                case TemplateTypeEnum.Approval_Check:
                    return new ChecklistApprovalFieldDictionary();
                case TemplateTypeEnum.Approval_NCR:
                    return new NcrApprovalFieldDictionary();
                case TemplateTypeEnum.Approval_PO:
                    return new PurchaseOrderApprovalFieldDictionary();
                case TemplateTypeEnum.Approval:
                    return new ApprovalFieldDictionary();
                case TemplateTypeEnum.Approval_Action_Advice:
                    return new ApprovalActionFieldDictionary();
                case TemplateTypeEnum.Contract_Notice_Response:
                    return new CnResponseFieldDictionary();
                case TemplateTypeEnum.Contract_Notice:
                    return new ContractNoticeFieldDictionary();
                case TemplateTypeEnum.Test_Request_Notification:
                    return new TestRequestNotificationFieldDictionary();
                case TemplateTypeEnum.Test_Request_Upload:
                    return new TestRequestNotificationFieldDictionary();
                case TemplateTypeEnum.Purchase_Order:
                    return new PurchaseOrderBaseFieldDictionary();
                case TemplateTypeEnum.Report_Send:
                    return null;
                case TemplateTypeEnum.User_Invite:
                    return new UserInviteFieldDictionary();
                case TemplateTypeEnum.User_Password_Reset:
                    return new UserPasswordResetFieldDictionary();
                case TemplateTypeEnum.Survey_Request_Notification:
                    return new SurveyNotificationFieldDictionary();
                case TemplateTypeEnum.Survey_Request_Upload:
                    return new SurveyNotificationFieldDictionary();
                case TemplateTypeEnum.Lot_Notification:
                    return new LotNotificationFieldDictionary();
                case TemplateTypeEnum.Ncr_Notification:
                    return new NcrNotificationFieldDictionary();
                case TemplateTypeEnum.Itp_Notification:
                    return new ItpNotificationFieldDictionary();
                case TemplateTypeEnum.Atp_Notification:
                    return new AtpNotificationFieldDictionary();
                case TemplateTypeEnum.Checklist_Notification:
                    return new ChecklistNotificationFieldDictionary();
                case TemplateTypeEnum.Approval_Notification:
                    return new ApprovalNotificationFieldDictionary();
                case TemplateTypeEnum.Daycost_Notification:
                    return null;
                case TemplateTypeEnum.PurchaseOrder_Notification:
                    return new PurchaseOrderNotificationFieldDictionary();
                case TemplateTypeEnum.Invoice_Notification:
                    return null;
                case TemplateTypeEnum.SiteDiary_Notification:
                    return new SiteDiaryNotificationFieldDictionary();
                case TemplateTypeEnum.Contract_Notice_Notification:
                    return new CnNotificationFieldDictionary();
                default: return null;
            }
        }

        private static void AddFieldsToDict(Dictionary<string, TemplateField> dctTF, List<TemplateField> lstTemplateField)
        {
            foreach (TemplateField tf in lstTemplateField)
            {
                dctTF[tf.fieldName] = tf;
                if (tf.lstSubFields.Count > 0) AddFieldsToDict(dctTF, tf.lstSubFields);
            }
        }

        public static Dictionary<string, string> TranslatorFromV10_ApprovalRequest()
        {
            var dctTranslate = new Dictionary<string, string>
            {
                ["Approval_ID"] = "Approval_No",
                ["Approval_ID_With_Link"] = "Approval_No_With_Link",
                ["Required_Date"] = "Action_Date",
                ["Request_To"] = "To_Name",
                ["Request_To_Incl_Comp"] = "To_Name_and_company",
                ["Request_Date"] = "Created_Date"
            };
            return dctTranslate;
        }



        public static Dictionary<string, string> TranslatorFromV10_ApprovalAction()
        {
            var dctTranslate = new Dictionary<string, string>
            {
                ["Approval_ID"] = "Approval_No",
                ["Approval_ID_With_Link"] = "Approval_No_With_Link",
                ["Approval_Status"] = "Current_Status",
                ["Approval_Response"] = "Last_Action_Comment",
                ["Approval_Response_By"] = "Last_Action_By",
                ["Approval_Response_Date"] = "Date_Last_Status",
                ["Approval_Body"] = "Body",
                ["Approval_Subject"] = "Subject",
                ["Approval_Required_Date"] = "Action_Date",
                ["Request_Date"] = "Created_Date"
            };
            return dctTranslate;
        }

        public static Dictionary<string, string> TranslatorFromV10_Ncr()
        {
            var dctTranslate = new Dictionary<string, string>();
            return dctTranslate;
        }

        public static Dictionary<string, string> TranslatorFromV10_Checklist()
        {
            var dctTranslate = new Dictionary<string, string>
            {
                ["Lotnumber"] = "Lot_Number",
                ["LotNo_and_Reference_Text"] = "Lot_Number"
            };
            return dctTranslate;
        }

        public static Dictionary<string, string> TranslatorFromV10_PurchaseOrder()
        {
            var dctTranslate = new Dictionary<string, string>
            {
                ["PO_DisplayTotal"] = "PO_Total_Display",
                ["Item_DisplayTotal"] = "Item_Total_Display"
            };
            return dctTranslate;
        }

        public static Dictionary<string, string> TranslatorFromV10_PurchaseOrderNotification()
        {
            var dctTranslate = new Dictionary<string, string>
            {
                ["PO_DisplayTotal"] = "PO_Total_Display",
                ["Item_DisplayTotal"] = "Item_Total_Display"
            };
            return dctTranslate;
        }

        public static Dictionary<string, string> TranslatorFromV10_NoticeResponse()
        {
            var dctTranslate = new Dictionary<string, string>();
            return dctTranslate;
        }


        public static Dictionary<string, string> GetV10Translations(TemplateTypeEnum? templateType)
        {
            Dictionary<string, string> dctTranslations = new Dictionary<string, string>();
            if (templateType == TemplateTypeEnum.Approval_Action_Advice) dctTranslations = TranslatorFromV10_ApprovalAction();
            else if (templateType == TemplateTypeEnum.Approval) dctTranslations = TranslatorFromV10_ApprovalRequest();
            else if (templateType == TemplateTypeEnum.Approval_Check) dctTranslations = TranslatorFromV10_Checklist();
            else if (templateType == TemplateTypeEnum.Approval_NCR) dctTranslations = TranslatorFromV10_Ncr();
            else if (templateType == TemplateTypeEnum.Approval_PO) dctTranslations = TranslatorFromV10_PurchaseOrder();
            else if (templateType == TemplateTypeEnum.Contract_Notice_Response) dctTranslations = TranslatorFromV10_NoticeResponse();
            else if (templateType == TemplateTypeEnum.Purchase_Order) dctTranslations = TranslatorFromV10_PurchaseOrderNotification();
            return dctTranslations;
        }

    }
}