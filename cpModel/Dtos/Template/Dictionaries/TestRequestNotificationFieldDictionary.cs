
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request
    /// </summary>
    public class TestRequestNotificationFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Test_Request_Notification;

        public TestRequestNotificationFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            var lstFields = GetSet<TestRequestSetTemplateDto>("Test_Requests", "TestRequests", GetTestRequestTemplateFields);
            lstFields.Add(AddFsTemplates<FsTestReqTemplateDto>("Filestore_TestReqNo", "TestReqNo"));

            return lstFields;
        }

        public static List<TemplateField> GetTestRequestTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            lstFields.Add(new TemplateField("Test_Req_No", "TestRequestNo"));
            lstFields.Add(new TemplateField("Test_Req_To", "RequestToName"));
            lstFields.Add(new TemplateField("Test_Req_By", "RequestedByName"));
            lstFields.Add(new TemplateField("Date_Raised", "DateRaisedString"));
            lstFields.Add(new TemplateField("Date_Required", "DateRequiredString"));
            lstFields.Add(new TemplateField("Test_Description", "Description"));
            lstFields.Add(new TemplateField("Lot_Number", "LotNumber"));
            lstFields.Add(new TemplateField("Lot_Description", "LotDescription"));
            lstFields.Add(new TemplateField("Test_Info", "TestInfoString"));
            lstFields.Add(new TemplateField("Attachment_Count", "AttachmentCount"));

            lstFields.Add(new TemplateField("Test_Req_No_With_Link", "TestReqLink"));
            lstFields.Add(new TemplateField("Test_Req_Link_AsURL", "TestReqLinkSiteURL"));

            return lstFields;
        }


    }
}
