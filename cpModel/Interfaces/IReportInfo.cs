using System;

namespace cpModel.Interfaces
{
    public interface IReportInfo
    {
        string ProjectTitle { get; set; }
        string ReportTitle { get; set; }
        string RecordReference { get; set; }
        string FilterText { get; set; }
        bool IsRegisterReport { get; set; }
        bool IsCustomReport { get; set; }
    }
}
