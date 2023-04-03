using cpModel.Enums;
using System.Collections.Generic;

namespace cpModel.Dtos.Report
{
    public interface IItpDetailReportDto
    {
        int RecordId { get; }
        int? ParentId { get; }
        List<IItpTestReportDto> lstTest { get; }
        string QvcTextEffective { get; set; }
        bool? InspectRequired { get; set; }
        bool? VerifyRequired { get; set; }
        bool? AuthorityRequired { get; set; }
        string Clause { get; set; }
        bool HasTests { get; }
        int? Hpwpc { get; set; }
        string InspMeth { get; set; }
        decimal? ItemOrder { get; set; }
        int? ItemType { get; set; }
        bool? QvcInc { get; set; }
        string Records { get; set; }
        string ReferenceText { get; set; }
        string Responsibility { get; set; }


        HpWpCEnum? HpWpCTypeEnum { get; }
        ItpItemTypeEnum? ItemTypeEnum { get; }
        string ItemTypeString { get; }
        string HpWpCString { get; }

    }
}
