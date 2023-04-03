using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using cpShared.Extensions;
using System.Globalization;
using cpShared.Models;
using System.Reflection;

namespace cpShared.Extensions
{
    public static class TextFunctions
    {

        /// <summary> Changes the precision of a decimal number
        /// </summary>
        /// <param name="NumberToFormat"></param>
        /// <param name="NumberDec"></param>
        /// <returns></returns>

        public static string Left(this string str, int length)
        {
            return (str ?? "").Substring(0, Math.Min((str ?? "").Length, length));
        }

        public static string ToShortDateString(this DateTime _date, CultureInfo _culture)
        {
            if (_culture == null) return _date.ToShortDateString();
            return _date.ToString("d", _culture);
        }

        public static string Repeat(this string stringToRepeat, int repeat)
        {
            var builder = new StringBuilder(repeat * stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }
            return builder.ToString();
        }

        public static string Right(this string s, int count)
        {
            if (s.Length <= count) return s;
            return s.Substring(s.Length - count, count);
        }

        public static string RemoveTrailingNonNumeric(this string s)
        {
            int? LastIndex = s.LastNumericIndex();
            if (LastIndex == null || LastIndex == 0) return s;

            return s.Substring(0, (int)LastIndex + 1);
        }


        public static string NumericPart(this string str)
        {
            return string.Join(null, Regex.Split(str, "[^\\d]"));
        }

        public static string NumericPartDecimal(this string str)
        {
            return string.Join(null, Regex.Split(str, @"[^0-9\.]+"));
        }

        public static bool IsNumeric(this string str)
        {
            decimal resultCheck;
            if (decimal.TryParse(str, out resultCheck)) return true;
            else return false;
        }

        public static int? LastNumericIndex(this string str)
        {
            if (str == null) return null;
            if (str.Length == 0) return null;
            else
            {
                for (int i = str.Length - 1; i >= 0; i--)
                    if (str.Substring(i, 1).IsNumeric()) return i;
            }
            return null;
        }

        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]", invalidChars);
            return Regex.Replace(name, invalidReStr, "_");
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static string ChangeHTMLFormat(RichEditDocumentServer server, string originalHTMLText, Font newFont, Color? c)
        {
            server.Document.HtmlText = originalHTMLText;

            CharacterProperties cp = server.Document.BeginUpdateCharacters(server.Document.Range);
            cp.FontName = newFont.Name;
            cp.FontSize = newFont.Size;
            cp.Bold = newFont.Bold;
            cp.Italic = newFont.Italic;
            if (c != null) cp.ForeColor = c;
            cp.Strikeout = newFont.Strikeout ? StrikeoutType.Single : StrikeoutType.None;
            cp.Underline = newFont.Underline ? UnderlineType.Single : UnderlineType.None;
            server.Document.EndUpdateCharacters(cp);
            return server.HtmlText;
        }

        public static string ChangeHTMLFormat(RichEditDocumentServer server, string originalHTMLText, ITPFormatInfo formatInfo)
        {
            server.Document.HtmlText = originalHTMLText;

            CharacterProperties cp = server.Document.BeginUpdateCharacters(server.Document.Range);
            if (!string.IsNullOrWhiteSpace(formatInfo.fontFamily)) cp.FontName = formatInfo.fontFamily;
            if (formatInfo.fontSize != null && formatInfo.fontSize > 0) cp.FontSize = formatInfo.fontSize;
            if (formatInfo.IsBold != null) cp.Bold = formatInfo.IsBold;
            if (formatInfo.IsItalic != null) cp.Italic = formatInfo.IsItalic;
            if (!string.IsNullOrWhiteSpace(formatInfo.colorHex)) cp.ForeColor = formatInfo.GetColor();
            if (formatInfo.IsStrike != null)
                cp.Strikeout = formatInfo.IsStrike.Value ? StrikeoutType.Single : StrikeoutType.None;
            if (formatInfo.IsUnderline != null)
                cp.Underline = formatInfo.IsUnderline.Value ? UnderlineType.Single : UnderlineType.None;
            server.Document.EndUpdateCharacters(cp);
            return server.HtmlText;
        }

        //This is here just for retro compatibility for old reports
        public static string ChangeHTMLFormat(RichEditDocumentServer server, Font newFont, string originalHTMLText)
        {
            return ChangeHTMLFontNameAndSize(server, newFont, originalHTMLText);
        }

        public static string ChangeHTMLFontNameAndSize(RichEditDocumentServer server, Font newFont, string originalHTMLText)
        {
            server.Document.HtmlText = originalHTMLText;
            // Apply default formatting
            server.Document.DefaultCharacterProperties.FontName = newFont.Name;
            server.Document.DefaultCharacterProperties.FontSize = newFont.Size;

            CharacterProperties cp = server.Document.BeginUpdateCharacters(server.Document.Range);
            cp.FontName = newFont.Name;
            cp.FontSize = newFont.Size;
            server.Document.EndUpdateCharacters(cp);
            return server.HtmlText;
        }


        /// <summary> returns plain text from an rtf formatted string
        /// </summary>
        /// <param name="rtfHTMLText">The rtf formatted text</param>
        /// <returns>Plain text from rtfText</returns>
        public static string ConvertRTFOrHTML(this string rtfHTMLText, textFormat tf = textFormat.plain, bool isDefHTML = true)
        {
            if (string.IsNullOrEmpty(rtfHTMLText)) return "";
            using (RichEditDocumentServer docServer = new RichEditDocumentServer())
            {
                return ConvertRTFOrHTML(docServer, rtfHTMLText, tf, isDefHTML);
            }
        }


        public static bool IsHTMLish(this string str)
        {
            return str.Contains(@"</body>");
        }

        public static string ConvertRTFOrHTML(RichEditDocumentServer docServer, string rtfHTMLText, textFormat tf = textFormat.plain, bool isDefHTML = true)
        {
            if (rtfHTMLText == null) return null;
            try
            {
                string testString = rtfHTMLText.ToLower();
                // Convert the RTF to plain text.
                if (testString.Contains(@"\rtf1")) docServer.RtfText = rtfHTMLText;
                else if (testString.Contains(@"</html>") || testString.Contains(@"</body>") || isDefHTML) docServer.HtmlText = rtfHTMLText;
                else docServer.Text = rtfHTMLText;
                if (tf == textFormat.rtf) return docServer.RtfText;
                else if (tf == textFormat.html)
                {
                    var htmlExportOptions = new HtmlDocumentExporterOptions();
                    htmlExportOptions.TabMarker = "&nbsp;&nbsp;&nbsp;&nbsp;";
                    var doc = docServer.Document;
                    return doc.GetHtmlText(doc.Range, null, htmlExportOptions);
                }
                return docServer.Text;
            }
            catch (Exception)
            {
                return rtfHTMLText;
            }
        }

        public enum textFormat
        {
            rtf,
            html,
            plain
        }


        public static string InsertHTMLToBeginning(string htmlDocument, string insertHtml, InsertOptions insOption)
        {
            using (RichEditDocumentServer docServer = new RichEditDocumentServer())
            {
                docServer.Document.HtmlText = htmlDocument;
                docServer.Document.InsertHtmlText(docServer.Document.Range.Start, insertHtml, insOption);
                return docServer.Document.HtmlText;
            }
        }

        public static string GetDevexHTML(string templateSubject)
        {
            using (RichEditDocumentServer docServer = new RichEditDocumentServer())
            {
                docServer.Document.HtmlText = templateSubject;
                return docServer.Document.HtmlText;
            }
        }

        public static string ConvertHtmlToInline(string rtfHTMLText)
        {
            using (RichEditDocumentServer docServer = new RichEditDocumentServer())
            {
                if (string.IsNullOrEmpty(rtfHTMLText)) return "";
                if (!rtfHTMLText.Contains(@"<!DOCTYPE html")) return rtfHTMLText;
                try
                {
                    docServer.HtmlText = rtfHTMLText;
                    HtmlDocumentExporterOptions myExportOptions = new HtmlDocumentExporterOptions();
                    myExportOptions.EmbedImages = true;
                    myExportOptions.CssPropertiesExportType = CssPropertiesExportType.Inline;
                    var changedText = docServer.Document.GetHtmlText(docServer.Document.Range, null, myExportOptions);
                    return changedText;
                }
                catch (Exception)
                {
                    return rtfHTMLText;
                }
            }
        }

        public static string InsertHTMLTextAtEnd(string OriginalHTMLText, string HTMLToInsert)
        {
            using (RichEditDocumentServer docServer = new RichEditDocumentServer())
            {
                docServer.Document.HtmlText = OriginalHTMLText;
                docServer.Document.InsertHtmlText(docServer.Document.Range.End, HTMLToInsert, InsertOptions.MergeFormatting);
                return docServer.Document.HtmlText;
            }
        }

        public static string GetCorrectFormatString(int maxNo)
        {
            return "0".Repeat(maxNo.ToString().Length);
        }
        public static bool ValidateEmail(object value)
        {
            string ValidEmailRegex = "^([a-zA-Z0-9'_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";
            if (value == null) return false;
            string email = value.ToString();

            Regex r = new Regex(ValidEmailRegex, RegexOptions.Singleline);
            return r.IsMatch(email);
        }

        public static string Replace(this string str, string oldValue, string @newValue, StringComparison comparisonType)
        {

            // Check inputs.
            if (str == null)
            {
                // Same as original .NET C# string.Replace behavior.
                throw new ArgumentNullException(nameof(str));
            }
            if (str.Length == 0)
            {
                // Same as original .NET C# string.Replace behavior.
                return str;
            }
            if (oldValue == null)
            {
                // Same as original .NET C# string.Replace behavior.
                throw new ArgumentNullException(nameof(oldValue));
            }
            if (oldValue.Length == 0)
            {
                // Same as original .NET C# string.Replace behavior.
                throw new ArgumentException("String cannot be of zero length.");
            }

            StringBuilder resultStringBuilder = new StringBuilder(str.Length);
            bool isReplacementNullOrEmpty = string.IsNullOrEmpty(@newValue);

            // Replace all values.
            const int valueNotFound = -1;
            int foundAt;
            int startSearchFromIndex = 0;
            while ((foundAt = str.IndexOf(oldValue, startSearchFromIndex, comparisonType)) != valueNotFound)
            {

                // Append all characters until the found replacement.
                int @charsUntilReplacment = foundAt - startSearchFromIndex;
                bool isNothingToAppend = @charsUntilReplacment == 0;
                if (!isNothingToAppend)
                {
                    resultStringBuilder.Append(str, startSearchFromIndex, @charsUntilReplacment);
                }



                // Process the replacement.
                if (!isReplacementNullOrEmpty)
                {
                    resultStringBuilder.Append(@newValue);
                }


                // Prepare start index for the next search.
                // This needed to prevent infinite loop, otherwise method always start search 
                // from the start of the string. For example: if an oldValue == "EXAMPLE", newValue == "example"
                // and comparisonType == "any ignore case" will conquer to replacing:
                // "EXAMPLE" to "example" to "example" to "example" … infinite loop.
                startSearchFromIndex = foundAt + oldValue.Length;
                if (startSearchFromIndex >= str.Length)
                {
                    // It is end of the input string: no more space for the next search.
                    // The input string ends with a value that has already been replaced. 
                    // Therefore, the string builder with the result is complete and no further action is required.
                    return resultStringBuilder.ToString();
                }
            }


            // Append the last part to the result.
            int @charsUntilStringEnd = str.Length - startSearchFromIndex;
            resultStringBuilder.Append(str, startSearchFromIndex, @charsUntilStringEnd);


            return resultStringBuilder.ToString();

        }

        public static void SetMessage(this Exception exception, string message)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            var type = typeof(Exception);
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var fieldInfo = type.GetField("_message", flags);
            fieldInfo.SetValue(exception, message);
        }

        public static string PrintStringWithNonPrintable(this string qryString)
        {
            return Regex.Replace(qryString,
              @"\p{Cc}",
              a => string.Format("[{0:X2}]", (byte)a.Value[0])
            );
        }
    }
}
