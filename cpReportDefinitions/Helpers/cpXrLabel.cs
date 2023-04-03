using DevExpress.Utils.Serializing;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Text;
using System.Text.RegularExpressions;

namespace cpReportDefinitions.Controls
{
    [ToolboxItem(true)]
    public class cpXrLabel : XRLabel
    {
        public cpXrLabel() : base()
        {
            this.BeforePrint += CpXrLabel_BeforePrint;
            Multiline = true;
        }

        private void CpXrLabel_BeforePrint(object sender, CancelEventArgs e)
        {
            if (sender is cpXrLabel edit)
            {
                if (Regex.Match(edit.Value.ToString(), "(?<!\r)\n").Success)
                {
                    edit.Value = Regex.Replace(edit.Text, "(?<!\r)\n", Environment.NewLine);
                }
            }
        }
    }
}
