using cpModel.Enums;
using System;
using System.Collections.Generic;

namespace cpModel.Dtos.Template
{
    /// <summary>
    /// An object containing the information necessary to replace fields in a string of HTML text with properties from an object,
    /// including a resolver which processes a specific field for a given object.
    /// </summary>
    public interface IFieldDictionaryBase
    {
        /// <summary>
        /// A processor that takes a variable name and an object and provides a list of strings representing the property value
        /// for the property equal to the variable name.
        /// </summary>
        /// <param name="variableName">The name of the property to resolve</param>
        /// <param name="objectDataSource">The object to resolve</param>
        /// <returns> list of strings containing the formatted string representation of the object property(s)</returns>
        List<string> GetInsertionCollection(string variableName, Object objectDataSource);

        /// <summary>
        /// A dictionary with a key representing a variable name, and a value containing the matching property name,
        /// formatting information for string conversion and other metadata
        /// </summary>
        Dictionary<string, TemplateField> DctTemplateFields { get; }

        /// <summary>
        /// The HTML Template to resolve which may contain fields contained in DctTemplateFields
        /// </summary>
        string HTMLTemplateText { get; set; }

        TemplateTypeEnum TemplateType { get; }
    }
}
