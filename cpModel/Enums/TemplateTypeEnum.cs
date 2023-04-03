using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum TemplateTypeEnum
    {
        Approval_Check = 1,
        Approval_NCR = 2,
        Approval_PO = 3,
        Approval = 10,
        Approval_Action_Advice = 11,
        Contract_Notice_Response = 20,
        Contract_Notice = 21,
        Test_Request_Notification = 30,
        Test_Request_Upload = 31,
        Purchase_Order = 40,
        Report_Send = 100,
        User_Invite = 200,
        User_Password_Reset = 201,
        Survey_Request_Notification = 300,
        Survey_Request_Upload = 301,
        Lot_Notification = 500,
        Ncr_Notification = 600,
        Itp_Notification = 700,
        Atp_Notification = 750,
        Checklist_Notification = 800,
        Approval_Notification = 900,
        Daycost_Notification = 1100,
        PurchaseOrder_Notification = 1200,
        Invoice_Notification = 1300,
        SiteDiary_Notification = 1400,
        Contract_Notice_Notification = 2100
    }
}
