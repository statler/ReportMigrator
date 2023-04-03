using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Template
{
    internal class SurveyRequestUploadFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Survey_Request_Upload;

        public SurveyRequestUploadFieldDictionary() : base()
        {
        }

        public override List<TemplateField> GetTemplateFields()
        {
            return GetSurveyRequestSetTemplateFields();
        }

        public static List<TemplateField> GetSurveyRequestSetTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            var ai = new TemplateField("Survey_Requests", "SurveyRequests");
            foreach (TemplateField templateField in GetSurveyRequestTemplateFields())
            {
                ai.AddSubField(templateField);
            }
            lstFields.Add(ai);
            return lstFields;
        }

        public static List<TemplateField> GetSurveyRequestTemplateFields()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            var ai = new TemplateField("Survey_Requests", "SurveyRequests");
            foreach (TemplateField templateField in SurveyRequestFieldDictionary.GetSurveyRequestSetTemplateFields())
            {
                ai.AddSubField(templateField);
            }
            var fs = new TemplateField("Attachments", "FilestoreDocsOrdered");
            fs.AddSubField(new TemplateField("Filestore_SurveyReqNo", "SurveyRequestNo"));
            fs.AddSubField(new TemplateField("Filestore_No", "FsNo"));
            fs.AddSubField(new TemplateField("Filestore_No_And_Description", "FsDescription"));
            fs.AddSubField(new TemplateField("Filestore_Date", "FileDateAsString"));
            fs.AddSubField(new TemplateField("Description", "FileDesc"));
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
            lstFields.Add(ai);
            lstFields.Add(fs);
            return lstFields;

        }
    }
}

