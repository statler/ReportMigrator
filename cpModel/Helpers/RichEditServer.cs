using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using System;
using System.Drawing;

namespace cpModel.Helpers
{
    public static class RichEditServer
    {

        /// <summary> returns plain text from an rtf formatted string
        /// </summary>
        /// <param name="rtfHTMLText">The rtf formatted text</param>
        /// <returns>Plain text from rtfText</returns>
        public static string GetPlainTextFromHTML(this string HTMLText)
        {
            if (String.IsNullOrEmpty(HTMLText)) return "";
            try
            {
                using (var RichEditServerInstance = new RichEditProcessor())
                {
                    return RichEditServerInstance.GetPlainTextFromHTML(HTMLText);
                }
            }
            catch (Exception)
            {
                return HTMLText;
            }
        }

    }

}
