using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using System;
using System.Drawing;

namespace cpModel.Helpers
{
    public class RichEditProcessor : IDisposable
    {

        public RichEditDocumentServer RichEditServer => _richEditServerInstance;
        RichEditDocumentServer _richEditServerInstance;
        public RichEditProcessor()
        {
            _richEditServerInstance = new RichEditDocumentServer();
        }


        /// <summary> returns plain text from an rtf formatted string
        /// </summary>
        /// <param name="rtfHTMLText">The rtf formatted text</param>
        /// <returns>Plain text from rtfText</returns>
        public string GetPlainTextFromHTML(string HTMLText)
        {
            return GetPlainTextFromHTML(_richEditServerInstance, HTMLText);
        }

        public static string GetPlainTextFromHTML(RichEditDocumentServer _richEditServerInstance, string HTMLText)
        {
            if (String.IsNullOrEmpty(HTMLText)) return "";
            try
            {
                _richEditServerInstance.HtmlText = HTMLText;
                PlainTextDocumentExporterOptions myExportOptions = new PlainTextDocumentExporterOptions();
                return _richEditServerInstance.Document.GetText(_richEditServerInstance.Document.Range, myExportOptions);
            }
            catch (Exception)
            {
                return HTMLText;
            }
        }

        public string GetPlainTextFromRtf(string RTFText)
        {
            return GetPlainTextFromRtf(_richEditServerInstance, RTFText);
        }
        public static string GetPlainTextFromRtf(RichEditDocumentServer _richEditServerInstance, string RTFText)
        {
            if (String.IsNullOrEmpty(RTFText)) return "";
            try
            {
                _richEditServerInstance.RtfText = RTFText;
                PlainTextDocumentExporterOptions myExportOptions = new PlainTextDocumentExporterOptions();
                return _richEditServerInstance.Document.GetText(_richEditServerInstance.Document.Range, myExportOptions);
            }
            catch (Exception)
            {
                return RTFText;
            }
        }

        public string GetDevexHTML(string HTMLText)
        {
            _richEditServerInstance.Document.HtmlText = HTMLText;
            return _richEditServerInstance.Document.HtmlText.Replace(@"<br/>", "<br>");
        }

        public string InsertHTMLTextAtEnd(string OriginalHTMLText, string HTMLToInsert)
        {
            _richEditServerInstance.Document.HtmlText = OriginalHTMLText;
            _richEditServerInstance.Document.InsertHtmlText(_richEditServerInstance.Document.Range.End, HTMLToInsert, InsertOptions.MergeFormatting);
            return _richEditServerInstance.Document.HtmlText.Replace(@"<br/>", "<br>");
        }

        public string JoinHTML(string startTextHtml, string endTextHtml)
        {
            _richEditServerInstance.Document.HtmlText = startTextHtml;
            _richEditServerInstance.Document.InsertHtmlText(_richEditServerInstance.Document.Range.End, endTextHtml, InsertOptions.KeepSourceFormatting);
            return _richEditServerInstance.Document.HtmlText.Replace(@"<br/>", "<br>");
        }

        public string InsertHTMLToBeginning(string htmlDocument, string insertHtml, InsertOptions insOption)
        {
            _richEditServerInstance.Document.HtmlText = htmlDocument;
            _richEditServerInstance.Document.InsertHtmlText(_richEditServerInstance.Document.Range.Start, insertHtml, insOption);
            return _richEditServerInstance.Document.HtmlText.Replace(@"<br/>", "<br>");
        }

        public string ConvertHtmlToRichText(string rtfHTMLText)
        {
            if (String.IsNullOrEmpty(rtfHTMLText)) return "";
            try
            {
                _richEditServerInstance.HtmlText = rtfHTMLText;
                RtfDocumentExporterOptions myExportOptions = new RtfDocumentExporterOptions();
                return _richEditServerInstance.Document.GetRtfText(_richEditServerInstance.Document.Range, myExportOptions);
            }
            catch (Exception)
            {
                return rtfHTMLText;
            }
        }

        public string ConvertHtmlToInline(string rtfHTMLText)
        {
            if (String.IsNullOrEmpty(rtfHTMLText)) return "";
            if (!rtfHTMLText.Contains(@"<!DOCTYPE html")) return rtfHTMLText;
            try
            {
                _richEditServerInstance.HtmlText = rtfHTMLText;
                HtmlDocumentExporterOptions myExportOptions = new HtmlDocumentExporterOptions();
                myExportOptions.EmbedImages = true;
                myExportOptions.CssPropertiesExportType = CssPropertiesExportType.Inline;
                var changedText = _richEditServerInstance.Document.GetHtmlText(_richEditServerInstance.Document.Range, null, myExportOptions);
                return changedText.Replace(@"<br/>", "<br>");
            }
            catch (Exception)
            {
                return rtfHTMLText;
            }
        }

        public string ChangeHTMLFontNameAndSize(Font newFont, string originalHTMLText)
        {
            _richEditServerInstance.Document.HtmlText = originalHTMLText;
            // Apply default formatting
            _richEditServerInstance.Document.DefaultCharacterProperties.FontName = newFont.Name;
            _richEditServerInstance.Document.DefaultCharacterProperties.FontSize = newFont.Size;

            CharacterProperties cp = _richEditServerInstance.Document.BeginUpdateCharacters(_richEditServerInstance.Document.Range);
            cp.FontName = newFont.Name;
            cp.FontSize = newFont.Size;
            _richEditServerInstance.Document.EndUpdateCharacters(cp);
            return _richEditServerInstance.HtmlText;
        }

        #region  IDisposable
        private bool _disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_richEditServerInstance != null)
                {
                    try
                    {
                        _richEditServerInstance.Dispose();
                    }
                    catch (Exception)
                    {

                    }
                    _richEditServerInstance = null;
                }
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }

}
