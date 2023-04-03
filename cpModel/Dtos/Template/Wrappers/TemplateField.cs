using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace cpModel.Dtos.Template
{
    public class TemplateField
    {
        public string fieldName { get; set; }
        public string objectProperty { get; set; }
        public string toStringFormat { get; set; }
        public bool shouldHide { get; set; }
        public List<TemplateField> lstSubFields { get; set; } = new List<TemplateField>();
        public TemplateField ParentField { get; set; }

        public TemplateField(string fieldName, string objectProperty)
        {
            this.fieldName = fieldName;
            this.objectProperty = objectProperty;
            lstSubFields = new List<TemplateField>();
        }

        public TemplateField(string fieldName, string objectProperty, string toStringFormat = "", bool shouldHide = false)
        {
            this.fieldName = fieldName;
            this.objectProperty = objectProperty;
            this.toStringFormat = toStringFormat;
            this.shouldHide = shouldHide;
            lstSubFields = new List<TemplateField>();
        }

        public void AddSubField(TemplateField ChildField)
        {
            lstSubFields.Add(ChildField);
            ChildField.ParentField = this;
        }

    }
}