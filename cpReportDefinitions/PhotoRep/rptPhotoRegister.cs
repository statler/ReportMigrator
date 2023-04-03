namespace cpReportDefinitions.PhotoRep
{
    public partial class rptPhotoRegister : rptTemplate
    {
        public override string BaseReportName { get; set; } = "Photo Register";
        public rptPhotoRegister()
        {
            InitializeComponent();
            ReportTitle = "Photo Register";
            IsRegisterReport = true;
        }

    }
}
