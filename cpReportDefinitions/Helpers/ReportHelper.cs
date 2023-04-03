using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace cpReportDefinitions
{
    public class ReportHelper
    {
        public static XRTableCell newTableCell(string cellText, TextAlignment textAlignmentMiddleCenter, double szWght, BorderSide borders, Font font)
        {
            XRTableCell newCell = new XRTableCell();
            newCell.Dpi = 254F;
            newCell.Font = font;
            newCell.Borders = borders;
            newCell.Padding = new PaddingInfo(10, 10, 10, 10, 254F);
            newCell.Text = cellText;
            newCell.TextAlignment = textAlignmentMiddleCenter;
            newCell.Weight = szWght;
            return newCell;
        }

        public static XRTableCell newTableCell(string cellText, TextAlignment textAlignmentMiddleCenter, float wdth, Font font)
        {
            XRTableCell newCell = new XRTableCell();
            newCell.Dpi = 254F;
            newCell.Font = font;
            newCell.Padding = new PaddingInfo(10, 10, 10, 10, 254F);
            newCell.Text = cellText;
            newCell.TextAlignment = textAlignmentMiddleCenter;
            newCell.WidthF = wdth;
            return newCell;
        }
    }
}
