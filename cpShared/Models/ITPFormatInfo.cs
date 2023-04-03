using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace cpShared.Models
{
    public class ITPFormatInfo
    {
        public List<int> DetailIds { get; set; }

        public string colorHex { get; set; }
        public string fontFamily { get; set; }
        public float? fontSize { get; set; }
        public bool? IsBold { get; set; }
        public bool? IsUnderline { get; set; }
        public bool? IsItalic { get; set; }
        public bool? IsStrike { get; set; }

        public Color? GetColor()
        {
            if (string.IsNullOrWhiteSpace(colorHex)) return null;
            try
            {
                return ColorTranslator.FromHtml(String.Format("#{0}", colorHex));
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
