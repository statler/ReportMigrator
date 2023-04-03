using cpModel.Enums;
using Pather.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// The abstract implementation of ITemplateBase that provides some helper functions common to most implementations
    /// and the default implementation of the template resolver.
    /// </summary>
    public abstract class FieldDictionaryBase : IFieldDictionaryBase
    {
        public Dictionary<string, TemplateField> DctTemplateFields { get; private set; }

        /// <summary>
        /// The HTML Template to resolve which may contain fields contained in DctTemplateFields
        /// </summary>
        public string HTMLTemplateText { get; set; }

        public abstract TemplateTypeEnum TemplateType { get; }

        public FieldDictionaryBase()
        {
            DctTemplateFields = new Dictionary<string, TemplateField>();
            AddFieldsToDict(GetTemplateFields());
        }

        /// <summary>
        /// Formats the resolved property to a string using a format string
        /// </summary>
        /// <param name="resolvedProperty">The resolved property</param>
        /// <param name="formatToUse">The format string to be used for the supplied property</param>
        /// <returns></returns>
        internal string GetFormattedObject(object resolvedProperty, string formatToUse)
        {
            if (resolvedProperty is DateTime dt && dt == DateTime.MinValue) resolvedProperty = null;
            if (resolvedProperty == null) return "";

            if (string.IsNullOrWhiteSpace(formatToUse)) return resolvedProperty.ToString();
            if (resolvedProperty is DateTime) return ((DateTime)resolvedProperty).ToString(formatToUse);
            else if (resolvedProperty is Decimal) return ((Decimal)resolvedProperty).ToString(formatToUse);
            else if (resolvedProperty is Double) return ((Double)resolvedProperty).ToString(formatToUse);
            else if (resolvedProperty is float) return ((float)resolvedProperty).ToString(formatToUse);
            return "";
        }

        /// <summary>
        /// The default instantiation of the GetInsertionCollection interface for resolving basic templates
        /// </summary>
        /// <param name="variableName">The name of the property to resolve</param>
        /// <param name="objectDataSource">The object to resolve</param>
        /// <returns> list of strings containing the formatted string representation of the object property(s)</returns>
        public virtual List<string> GetInsertionCollection(string variableName, object objectDataSource)
        {
            Resolver r = new Resolver();
            bool hasError = false;
            List<string> lstInsertText = new List<string>();
            if (DctTemplateFields.ContainsKey(variableName))
            {
                try
                {
                    var field = DctTemplateFields[variableName];
                    object foundObj = r.Resolve(objectDataSource, field.objectProperty);

                    if (foundObj is Selection asel)
                    {
                        foreach (object item in asel)
                            lstInsertText.Add(GetFormattedObject(item, field.toStringFormat));
                    }
                    else lstInsertText.Add(GetFormattedObject(foundObj, field.toStringFormat));
                }
                catch (Exception)
                {
                    hasError = true;
                }
            }

            if (lstInsertText.Count == 0 && hasError) lstInsertText.Add("");
            return lstInsertText;
        }

        /// <summary>
        /// A recursive function that extends a dictionary of variablenames vs. property resolution information using
        /// lists of the same information
        /// </summary>
        /// <param name="dctTF">The existing dictionary of variables and properties to be extended</param>
        /// <param name="lstTemplateField">The list of variable/property information to be added to the dictionary</param>
        public void AddFieldsToDict(List<TemplateField> lstTemplateField)
        {
            foreach (TemplateField tf in lstTemplateField)
            {
                DctTemplateFields[tf.fieldName] = tf;
                if (tf.lstSubFields.Count > 0) AddFieldsToDict(tf.lstSubFields);
            }
        }

        public abstract List<TemplateField> GetTemplateFields();


        internal static List<TemplateField> GetSet<T>(string SetDescriptor, string SetFieldName, Func<List<TemplateField>> fnSublist) where T : TemplateSetBaseDto
        {
            var lstFields = InitFieldListWithProjectInfo();
            var ai = new TemplateField(SetDescriptor, SetFieldName);
            var collectionType = typeof(T).GetProperties().FirstOrDefault(x => x.Name == SetFieldName).PropertyType;
            if (collectionType == null) throw new ApplicationException($"Could not find collection {SetFieldName} in type {typeof(T).Name}");
            var lstProps = new HashSet<string>(collectionType.GetGenericArguments()[0].GetProperties().Select(x => x.Name));
            foreach (TemplateField templateField in fnSublist())
            {
                if (!lstProps.Contains(templateField.objectProperty))
                    throw new ApplicationException($"Could not find field {templateField.objectProperty} in collection {SetFieldName} type {typeof(T).Name}");
                ai.AddSubField(templateField);
            }
            lstFields.Add(ai);
            return lstFields;
        }

        internal static TemplateField AddFsTemplates<T>(string ParentRef, string ParentRef_Field) where T : IFilestoreDocsBase
        {
            var lstProps = new HashSet<string>(typeof(T).GetProperties().Select(x => x.Name));
            var fs = new TemplateField("Attachments", "FilestoreDocsOrdered");
            fs.AddSubField(new TemplateField(ParentRef, ParentRef_Field));

            fs.AddSubField(new TemplateField("Filestore_No", "FsNo"));
            fs.AddSubField(new TemplateField("Filestore_No_And_Description", "FsDescription"));
            fs.AddSubField(new TemplateField("Filestore_Date", "FileDateAsString"));
            fs.AddSubField(new TemplateField("Description", "FileDesc"));
            foreach (TemplateField templateField in fs.lstSubFields)
            {
                if (!lstProps.Contains(templateField.objectProperty))
                    throw new ApplicationException($"Could not find field {templateField.objectProperty} in collection {ParentRef_Field} type {typeof(T).Name}");
            }
            return fs;
        }

        static List<TemplateField> InitFieldListWithProjectInfo()
        {
            List<TemplateField> lstFields = new List<TemplateField>();
            AddProjectFields(lstFields);
            return lstFields;
        }

        static void AddProjectFields(List<TemplateField> lstFields)
        {
            lstFields.Add(new TemplateField("Project_Name", "ProjectName"));
            lstFields.Add(new TemplateField("Project_Number", "ProjectNumber"));
        }
    }
}
