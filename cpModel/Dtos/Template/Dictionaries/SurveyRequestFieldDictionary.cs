using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Dtos.Template
{
    internal class SurveyRequestFieldDictionary : FieldDictionaryBase, IFieldDictionaryBase
    {
        public override TemplateTypeEnum TemplateType => TemplateTypeEnum.Survey_Request_Upload;

        public SurveyRequestFieldDictionary() : base()
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
            lstFields.Add(new TemplateField("Survey_Req_No", "SrNumber"));
            lstFields.Add(new TemplateField("Survey_Req_To", "RequestToName"));
            lstFields.Add(new TemplateField("Survey_Req_By", "RequestByName"));
            lstFields.Add(new TemplateField("Date_Raised", "DateRaisedString"));
            lstFields.Add(new TemplateField("Date_Required", "DateRequiredString"));
            lstFields.Add(new TemplateField("Survey_Description", "Description"));
            lstFields.Add(new TemplateField("Survey_Type", "SurveyTypeDesc"));
            lstFields.Add(new TemplateField("Lot_Number", "LotInfoCSVString"));

            lstFields.Add(new TemplateField("Survey_Req_No_With_Link", "SurveyReqLink"));
            lstFields.Add(new TemplateField("Survey_Req_Link_AsURL", "SurveyReqLinkSiteURL"));

            return lstFields;

        }
    }
    }
