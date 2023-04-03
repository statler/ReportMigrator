using DevExpress.XtraReports.UI;

namespace cpReportDefinitions.UserRep
{
    public partial class rptUserRoles_byUser : rptTemplate
    {
        public override string BaseReportName { get; set; } = "User Roles (by User)";

        public rptUserRoles_byUser()
        {
            InitializeComponent();
            ReportTitle = "User Roles (by User)";
        }

        int counter = 0;
        object groupValue = null;
        XRControlStyle _currStyle = null;
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            (sender as DetailBand).BackColor = _currStyle.BackColor;
        }

        private void GroupHeader_User_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (counter % 2 == 0) _currStyle = Style1;
            else _currStyle = Style2;

            (sender as GroupHeaderBand).BackColor = _currStyle.BackColor;
            object currentGroupValue = ((GroupHeaderBand)sender).Report.GetCurrentColumnValue("UserId");

            if (groupValue != currentGroupValue)
            {
                groupValue = currentGroupValue;
                counter++;
            }
        }

        private void GroupHeader_Project_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            (sender as GroupHeaderBand).BackColor = _currStyle.BackColor;
        }
    }
}
