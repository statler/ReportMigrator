using cpModel.Dtos.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public partial class LotReportDto : LotDto
    {
        public string ConformedByName { get; set; }
        public string WorkTypeName { get; set; }
        public string AreaCodeName { get; set; }

        public string GeometryString
        {
            get
            {
                return string.Join(Environment.NewLine, GetGeomStrList().ToArray());
            }
        }

        public string PropertyString
        {
            get
            {
                List<string> props = new List<string>();
                if ((LotLength ?? 0) != 0)
                    props.Add($"Length: {LotLength:#,###,##0.###}m");
                if ((LotArea ?? 0) != 0)
                    props.Add($"Area: {LotArea:#,###,##0.###}m2");
                if ((LotVolume ?? 0) != 0)
                    props.Add($"Volume: {LotVolume:#,###,##0.###}m3");
                return string.Join(Environment.NewLine, props.ToArray()); ;
            }
        }

        public List<string> GetGeomStrList()
        {
            return GetGeomStrList(true);
        }

        public List<string> GetGeomStrList(bool IsLong)
        {
            List<string> geoms = new List<string>();
            if (GeometryType == 1) geoms.Add("No geometry defined.");

            geoms.Add(ControlLineName ?? "");
            if (HasChainageData)
            {
                if ((StLeftOs ?? 0) != 0 || (StRightOs ?? 0) != 0 || (EndLeftOs ?? 0) != 0 || (EndRightOs ?? 0) != 0)
                {
                    geoms.Add($"Ch (st):{ChStart:#,###,##0.###} o/s {StLeftOs:#,###,##0.###} to {StRightOs:#,###,##0.###}");
                    geoms.Add($"Ch (end):{ChEnd:#,###,##0.###} o/s {EndLeftOs:#,###,##0.###} to {EndRightOs:#,###,##0.###}");
                }
                else if ((ChStart ?? 0) != 0 || (ChEnd ?? 0) != 0) geoms.Add($"Ch: {ChStart:#,###,##0.###} to {ChEnd:#,###,##0.###}");

                if ((!string.IsNullOrEmpty(Rl1 + Rl2) || (NominalThickness ?? 0) > 0) && IsLong) geoms.Add("");
                if (!string.IsNullOrEmpty(Rl1) && IsLong) geoms.Add($"RL1: {Rl1} ");
                if (!string.IsNullOrEmpty(Rl2) && IsLong) geoms.Add($"RL2: {Rl2} ");
                if ((NominalThickness ?? 0) > 0 && IsLong) geoms.Add($"Thickness: {NominalThickness:#,###,##0.###}mm");
            }

            if (GeometryType > 2)
            {
                if (HasChainageData) geoms.Add("");
                if (LotCoordinateDtos != null)
                {
                    foreach (LotCoordinateDto coordinate in LotCoordinateDtos)
                        geoms.Add(string.Format("x:{0} y:{1} z:{2}", coordinate.Xcoord, coordinate.Ycoord, coordinate.Zcoord));
                }
            }
            return geoms;
        }

        bool HasChainageData => ((ChStart ?? 0) != 0) || ((ChEnd ?? 0) != 0) || (this.ControlLineId != null);

        public List<LotCoordinateDto> LotCoordinateDtos { get; set; }
        public List<LotQuantityReportDto> Quantities { get; set; }
        public List<ChecklistReportDto> Checklists { get; set; }
        public List<NcrLookupDto> Ncrs { get; set; }
        public List<LotConfApprovalReportDto> Approvals { get; set; }
        public List<AtpLotForConfReportDto> Atps { get; set; }
        public List<PhotoLotReportDto> Photos { get; set; }
        public List<VariationLotReportDto> Variations { get; set; }
        public List<LotRelatedReportDto> RelatedLots { get; set; }
        public List<TestResultFieldDto> ResultFields { get; set; }
        public List<TestRequestTestReportDto> Tests { get; set; }
        public List<CustomRegisterValueReportDto> CustomRegisters { get; set; }

        public List<TestSummaryReportDto> TestSets
        {
            get
            {
                var testProc = Tests.Where(x => x.TestRequestNo != null && x.LotId != null)
                    .GroupBy(x => new { x.TestRequestNo, x.TestMethodId, x.TestMethodNum, x.TestMethodDesc, x.ScheduleNo, x.LotId })
                    .Select(x => new { x.Key.TestRequestNo, x.Key.TestMethodId, x.Key.TestMethodNum, x.Key.TestMethodDesc, x.Key.ScheduleNo, x.Key.LotId, NoOfTests = x.Count() })
                    .ToList();
                return testProc.Select(x => new TestSummaryReportDto()
                {
                    LotId = x.LotId.Value,
                    ScheduleName = x.ScheduleNo ?? "",
                    TestMethodId = x.TestMethodId,
                    TestMethodName = x.TestMethodNum,
                    TestMethodDescription = x.TestMethodDesc,
                    TestReqNo = x.TestRequestNo.Value,
                    NoOfTests = x.NoOfTests
                }).OrderBy(x => x.TestReqNo).ThenBy(x => x.TestMethodName).ToList();
            }
        }
        public List<TestMethodLookupDto> TestMethods
        {
            get
            {
                if (Tests == null) return null;
                return Tests.Where(x => x.TestMethodId != null)
                    .Select(x => new TestMethodLookupDto() { TestMethodId = x.TestMethodId.Value, TestNum = x.TestMethodNum, TestDescription = x.TestMethodDesc })
                      .GroupBy(p => p.TestMethodId)
                      .Select(g => g.FirstOrDefault())
                      .OrderBy(x => x.TestNum)
                      .ToList();
            }
        }
    }

}
