using System;
using System.Collections.Generic;
using System.Linq;

namespace cpReportDefinitions.Helpers
{
    public class CharacteristicValue
    {

        double[,] _acList = new double[,] { { 10, 0.828 }, { 11, 0.847 }, { 12, 0.863 }, { 13, 0.877 }, { 14, 0.89 }, { 15, 0.901 }, { 20, 0.946 }, { 25, 0.978 }, { 30, 1.002 }, { 35, 1.02 }, { 40, 1.036 }, { 45, 1.049 }, { 50, 1.059 }, { 60, 1.077 }, { 70, 1.091 }, { 80, 1.103 }, { 90, 1.112 }, { 100, 1.12 } };
        List<double[]> _lstAC = new List<double[]>();

        double _sumValue;
        double _stDev;
        double _kVal;
        public List<double> ValueList { get; set; }

        public CharacteristicValue(List<double> valueList)
        {
            ValueList = valueList;
            CheckOverrides();
            _stDev = (double)StatisticsExtensions.StandardDeviationSample(ValueList);
            _sumValue = ValueList.Average();

            SetkVal();
        }

        public CharacteristicValue()
        {
            CheckOverrides();
        }

        public double GetCVLower()
        {
            return _sumValue - _kVal * _stDev;
        }

        public double GetCVUpper()
        {
            return _sumValue + _kVal * _stDev;
        }

        private void SetkVal()
        {
            int n = ValueList.Count;
            IOrderedEnumerable<double[]> lstACOrderBy = _lstAC.OrderBy(x => x[0]);
            if (lstACOrderBy.Count() == 0) return;
            _kVal = lstACOrderBy.ElementAt(0)[1];
            foreach (double[] acItems in lstACOrderBy)
            {
                if (acItems[0] <= n) _kVal = acItems[1];
                else break;
            }
        }

        private void CheckOverrides()
        {
            //using (var xpoSession = new Session())
            //{
            //    CriteriaOperator findOperator = SQLHelper.StartsWith(SystemProjectControl.Fields.Key, "k");
            //    CriteriaOperator joinedOperator = GroupOperator.And(findOperator, SystemProjectControl.Fields.ProjectID.ProjectID == UserContext.ProjectId);
            //    var xpcProjectSettings = new XPCollection<SystemProjectControl>(xpoSession, joinedOperator);
            //    for (int i = 0; i < _acList.GetUpperBound(0); i++)
            //    {
            //        string acName = string.Format("k{0}", _acList[i, 0]);
            //        List<SystemProjectControl> kVal = xpcProjectSettings.Where(x => x.Key.ToLower() == acName.ToLower()).ToList();
            //        if (kVal.Count > 0)
            //        {
            //            double TestConstantValue = 0;
            //            if (double.TryParse(kVal[0].Value, out TestConstantValue)) _acList[i, 1] = TestConstantValue;
            //        }
            //        _lstAC.Add(new double[] { _acList[i, 0], _acList[i, 1] });
            //    }
            //}
            for (int i = 0; i < _acList.GetUpperBound(0); i++)
            {
                _lstAC.Add(new double[] { _acList[i, 0], _acList[i, 1] });
            }
        }

        public List<string> GetKValueList()
        {
            List<string> KValues = new List<string>();
            foreach (double[] acItems in _lstAC.OrderBy(x => x[0]))
            {
                KValues.Add(String.Format("{0}: {1}", acItems[0], acItems[1]));
            }
            return KValues;
        }
    }

}
