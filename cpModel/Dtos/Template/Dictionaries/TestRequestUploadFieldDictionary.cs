
using cpModel.Enums;

using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// Template information for resolving an approval request
    /// </summary>
    public class TestRequestUploadFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Test_Request_Upload;

        public TestRequestUploadFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetTestResultUploadTemplateFields();
        }

        public static List<TemplateField> GetTestResultUploadTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            var ai = new TemplateField("Test_Requests", "TestRequests");
            foreach (TemplateField templateField in TestRequestNotificationFieldDictionary.GetTestRequestTemplateFields())
            {
                ai.AddSubField(templateField);
            }
            var fs = new TemplateField("Attachments", "FilestoreDocsOrdered");
            fs.AddSubField(new TemplateField("Filestore_TestReqNo", "TestReqNo"));
            fs.AddSubField(new TemplateField("Filestore_No", "FsNo"));
            fs.AddSubField(new TemplateField("Description", "FileDesc"));
            fs.AddSubField(new TemplateField("Filestore_No_And_Description", "FsDescription"));
            fs.AddSubField(new TemplateField("Filestore_Date", "FileDateAsString"));
            lstFields.Add(ai);
            lstFields.Add(fs);
            return lstFields;
        }

    }
}
