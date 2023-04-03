using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Dtos.Report
{
    public partial class TestRequestReportDto : TestRequestWithGeometryDto
    {
        public string Source { get; set; }
        public decimal? DepthToTest { get; set; }
        public bool? IsAdvLocnDef { get; set; }
        public decimal? StLeftOs { get; set; }
        public decimal? StRightOs { get; set; }
        public decimal? EndLeftOs { get; set; }
        public decimal? EndRightOs { get; set; }
        public string LevelDatum { get; set; }
        public int? ControlLineId { get; set; }
        public int? LocateMethod { get; set; }
        public string Notes { get; set; }
        public bool? IsAvlOverride { get; set; }
        public decimal? TestLength { get; set; }
        public decimal? TestArea { get; set; }
        public decimal? TestVolume { get; set; }
        public DateTime? TimeReqd { get; set; }
        public int? TestType { get; set; }
        public int? ReferenceSystemTypeId { get; set; }
        public string ControlLineDescription { get; set; }

        public override bool TestComplete
        {
            get => DateTestCompleted != null;
            set => DateTestCompleted = (value ? DateTime.UtcNow : (DateTime?)null);
        }

        public string LotInclDef => $"{LotNumber}: {LotDescription}";

        public List<TestRequestTestReportDto> Tests { get; set; }
        public List<TestRequestPropertyDto> TestProperties { get; set; }
        public List<TestCoordinate> TestCoords { get; set; }
        public List<CustomRegisterValueReportDto> CustomRegisters { get; set; }

        public List<TestSummaryReportDto> TestSets
        {
            get
            {
                if (Tests == null) return new List<TestSummaryReportDto>();
                var testProc = Tests.Where(x => x.TestRequestNo != null && x.LotId != null)
                    .GroupBy(x => new { x.TestRequestNo, x.TestReqMarkedComplete, x.TestMethodId, x.TestMethodNum, x.TestMethodDesc, x.ScheduleNo, x.ScheduleDescription, x.LotId })
                    .Select(x =>
                        new
                        {
                            x.Key.TestRequestNo,
                            x.Key.TestMethodId,
                            x.Key.TestMethodNum,
                            x.Key.TestMethodDesc,
                            x.Key.ScheduleNo,
                            x.Key.ScheduleDescription,
                            x.Key.LotId,
                            IsComplete = x.All(tr => tr.TestComplete ?? false) || x.Key.TestReqMarkedComplete,
                            NoOfTests = x.Count(),
                            ComplianceReq = x.Select(y => y.ComplianceReq).FirstOrDefault(z => z != null)
                        })
                    .ToList();
                var testSets = testProc.Select(x => new TestSummaryReportDto()
                {
                    LotId = x.LotId.Value,
                    ScheduleName = x.ScheduleNo ?? "",
                    ScheduleDescription = x.ScheduleDescription ?? "",
                    TestMethodId = x.TestMethodId,
                    TestMethodName = x.TestMethodNum,
                    TestMethodDescription = x.TestMethodDesc,
                    TestReqNo = x.TestRequestNo.Value,
                    NoOfTests = x.NoOfTests,
                    ComplianceReq = x.ComplianceReq,
                    AllCompleted = x.IsComplete
                }).OrderBy(x => x.TestReqNo).ThenBy(x => x.TestMethodName).ToList();

                return testSets;
            }
        }

        public string TestTypeString
        {
            get
            {
                if (TestType == 1) return "Control";
                if (TestType == 2) return "Information";
                if (TestType == 3) return "Retest";
                else return "Compliance";
            }
        }

        public string geometryPropertyString
        {
            get
            {
                switch (GeometryType)
                {
                    case 1:
                        return "No Geometry";
                    case 2:
                        return "Chainage";
                    case 3:
                        return "Coord. Position";
                    case 4:
                        return "Coord. Region";
                    default:
                        return "Not Defined";
                }
            }
        }
        public string geometryString
        {
            get
            {
                return string.Join(Environment.NewLine, GetGeomStrList(true, true).ToArray());
            }
        }

        public string geometryStringLinear
        {
            get
            {
                return string.Join(" | ", GetGeomStrList(true, false).ToArray());
            }
        }

        public List<string> GetGeomStrList(bool IsLong, bool LongCL)
        {
            List<string> geoms = new List<string>();
            if (GeometryType == 1) geoms.Add("No geometry defined.");

            string control = ControlLineName;
            if (LongCL) control = $"{ControlLineName}: {ControlLineDescription}";

            geoms.Add(control);
            if (HasChainageData)
            {
                if ((StLeftOs ?? 0) != 0 || (StRightOs ?? 0) != 0 || (EndLeftOs ?? 0) != 0 || (EndRightOs ?? 0) != 0)
                {
                    geoms.Add($"Ch (st):{ChStart:#,###,##0.###} o/s {StLeftOs:#,###,##0.###} to {StRightOs:#,###,##0.###}");
                    geoms.Add($"Ch (end):{ChEnd:#,###,##0.###} o/s {EndLeftOs:#,###,##0.###} to {EndRightOs:#,###,##0.###}");
                }
                else if ((ChStart ?? 0) != 0 || (ChEnd ?? 0) != 0) geoms.Add($"Ch: {ChStart:#,###,##0.###} to {ChEnd:#,###,##0.###}");

                if (!string.IsNullOrEmpty(LevelDatum) && IsLong) geoms.Add($"RL1: {LevelDatum} ");
            }

            if (GeometryType > 2)
            {
                if (HasChainageData) geoms.Add("");
                foreach (TestCoordinate coordinate in TestCoords)
                    geoms.Add(string.Format("x:{0} y:{1} z:{2}", coordinate.Xcoord, coordinate.Ycoord, coordinate.Zcoord));
            }
            return geoms;
        }

        bool HasChainageData => ((ChStart ?? 0) != 0) || ((ChEnd ?? 0) != 0) || (ControlLineId != null);

        public string GeomStringShort
        {
            get
            {
                return string.Join(Environment.NewLine, GetGeomStrList(false, true).ToArray());
            }
        }

        public string PropertyString
        {
            get
            {
                List<string> props = new List<string>();
                if ((TestLength ?? 0) != 0)
                    props.Add($"Length: {TestLength:#,###,##0.###}m");
                if ((TestArea ?? 0) != 0)
                    props.Add($"Area: {TestArea:#,###,##0.###}m2");
                if ((TestVolume ?? 0) != 0)
                    props.Add($"Volume: {TestVolume:#,###,##0.###}m3");
                return string.Join(Environment.NewLine, props.ToArray()); ;
            }
        }
    }
}
