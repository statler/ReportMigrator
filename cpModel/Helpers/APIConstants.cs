
using cpModel.Enums;
using System;

namespace cpModel.Helpers
{
    public static class APIConstants
    {
        public static bool IsDesktop { get; set; } = false;
        public static string MobileSiteURL { get; set; }

        public static string GetURLString(TemplateTypeEnum _type, Guid id)
        {
            return GetURLString(_type, id.ToString());
        }

        public static string GetURLString(TemplateTypeEnum _type, int id)
        {
            return GetURLString(_type, id.ToString());
        }


        public static string GetURLString(TemplateTypeEnum _type, string id, string token = "")
        {
            if (string.IsNullOrEmpty(MobileSiteURL)) throw new ApplicationException("The MobileSiteURL is not set.");
            switch (_type)
            {
                case TemplateTypeEnum.Approval_Check:
                case TemplateTypeEnum.Checklist_Notification:
                    return $@"{MobileSiteURL}/checklists/{id}";
                case TemplateTypeEnum.Approval_NCR:
                case TemplateTypeEnum.Ncr_Notification:
                    return $@"{MobileSiteURL}/ncrs/{id}";
                case TemplateTypeEnum.Approval_PO:
                case TemplateTypeEnum.PurchaseOrder_Notification:
                    return $@"{MobileSiteURL}/purchase-orders/{id}";
                case TemplateTypeEnum.Report_Send:
                    throw new ApplicationException("The GetURLString method is not applicable for the given template.");

                case TemplateTypeEnum.Approval:
                case TemplateTypeEnum.Approval_Notification:
                case TemplateTypeEnum.Approval_Action_Advice:
                    return $@"{MobileSiteURL}/approvals/{id}";

                case TemplateTypeEnum.Contract_Notice:
                case TemplateTypeEnum.Contract_Notice_Notification:
                    return $@"{MobileSiteURL}/contract-notices/{id}";

                case TemplateTypeEnum.Contract_Notice_Response:
                    return $@"{MobileSiteURL}/cnresponses/{id}";

                case TemplateTypeEnum.Test_Request_Notification:
                case TemplateTypeEnum.Test_Request_Upload:
                    return $@"{MobileSiteURL}/test-requests/{id}";

                case TemplateTypeEnum.Survey_Request_Notification:
                case TemplateTypeEnum.Survey_Request_Upload:
                    return $@"{MobileSiteURL}/survey-requests/{id}";

                case TemplateTypeEnum.Lot_Notification:
                    return $@"{MobileSiteURL}/lots/{id}";

                case TemplateTypeEnum.Itp_Notification:
                    return $@"{MobileSiteURL}/itps/{id}";

                case TemplateTypeEnum.Atp_Notification:
                    return $@"{MobileSiteURL}/atps/{id}";

                case TemplateTypeEnum.Purchase_Order:
                    return $@"{MobileSiteURL}/purchase-orders/{id}";

                case TemplateTypeEnum.SiteDiary_Notification:
                     return $@"{MobileSiteURL}/site-diaries/{id}";

                case TemplateTypeEnum.User_Invite:
                    return $@"{MobileSiteURL}/user-invites/{id}";
                case TemplateTypeEnum.User_Password_Reset:
                    return $@"{MobileSiteURL}/UserReset?id={id}&uq={token}";
            };
            return null;
        }
    }
}
