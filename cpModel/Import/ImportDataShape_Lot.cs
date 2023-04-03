using System;
using System.Linq;
using System.Collections.Generic;
using cpModel.Models;

namespace cpModel.Import
{
    public class ImportDataShape_Lot : ImportDataShape
    {

        public ImportDataShape_Lot()
        {
            LstDataFields = new List<ImportDataField>();
            LstDataFields.Add(new ImportDataField("WorkType", "Work Type", false, 2, typeof(WorkType)));
            LstDataFields.Add(new ImportDataField("AreaCode", "Area Code", false, 4, typeof(AreaCode)));
            LstDataFields.Add(new ImportDataField("LotNumber", "Lot number", true, 30));
            LstDataFields.Add(new ImportDataField("Description", "Description", false, 3000));
            LstDataFields.Add(new ImportDataField("ControlLine", "Control Line", false, 50, typeof(ControlLine)));
            LstDataFields.Add(new ImportDataField("ChStart", "Start chainage", false));
            LstDataFields.Add(new ImportDataField("StLeftOs", "Start - Left OS", false));
            LstDataFields.Add(new ImportDataField("StRightOs", "Start - Right OS", false));
            LstDataFields.Add(new ImportDataField("ChEnd", "End chainage", false));
            LstDataFields.Add(new ImportDataField("EndLeftOs", "End - Left OS", false));
            LstDataFields.Add(new ImportDataField("EndRightOs", "End - Right OS", false));
            LstDataFields.Add(new ImportDataField("NominalThickness", "Nom Thickness", false));
            LstDataFields.Add(new ImportDataField("Rl1", "RL1", false, 50));
            LstDataFields.Add(new ImportDataField("Rl2", "RL2", false, 50));
            LstDataFields.Add(new ImportDataField("DateOpen", "Date opened", false));
            LstDataFields.Add(new ImportDataField("DateClosed", "Date closed", false));
            LstDataFields.Add(new ImportDataField("DateConf", "Date conformed", false));
            LstDataFields.Add(new ImportDataField("DateGuar", "Date guaranteed", false));
            LstDataFields.Add(new ImportDataField("DateWorkSt", "Date work start", false));
            LstDataFields.Add(new ImportDataField("DateWorkEnd", "Date work end", false));
            LstDataFields.Add(new ImportDataField("Notes", "Notes", false, 3000));
            LstDataFields.Add(new ImportDataField("RaisedBy", "Raised By", false, 200, typeof(User)));

            Audit();
        }

        internal override void Audit()
        {
            var _lType = typeof(Lot);
            var _targetProperties = _lType.GetProperties().Select(x => x.Name).ToList();
            var _invalidProperties = new List<string>();
            foreach (ImportDataField importDataField in GetValidateableFields())
            {
                if (!_targetProperties.Contains(importDataField.PropertyName)) _invalidProperties.Add(importDataField.PropertyName);
            }
            if (_invalidProperties.Count > 0) throw new ApplicationException($"Some import properties are incorrectly specified:{Environment.NewLine}{string.Join($",", _invalidProperties)}");
        }
    }
}
