using System;
using System.Collections.Generic;
using System.Linq;

namespace cpModel.Import
{
    abstract public class ImportDataShape
    {
        internal List<ImportDataField> LstDataFields = new List<ImportDataField>();

        public void Clear()
        {
            foreach (var df in LstDataFields)
                df.Revoke();
        }

        Dictionary<string, ImportDataField> GetFieldDictionary()
        {
            var _dct = new Dictionary<string, ImportDataField>();
            foreach (var _idf in LstDataFields)
            {
                _dct[_idf.FriendlyName] = _idf;
            }
            return _dct;
        }

        public ImportDataField GetFieldByAlias(string Alias)
        {
            var alias_lower = Alias.ToLower().Trim();
            return LstDataFields.FirstOrDefault(x => x.Aliases.Any(al => al.ToLower() == alias_lower));
        }


        public ImportDataField GetFieldByPropertyName(string propertyName)
        {
            return LstDataFields.FirstOrDefault(x => x.PropertyName == propertyName);
        }

        public int? GetColHandleByPropertyName(string propertyName)
        {
            return LstDataFields.FirstOrDefault(x => x.PropertyName == propertyName)?.AssignedColHandle;
        }

        public List<ImportDataField> GetUnassigned()
        {
            return LstDataFields.Where(x => !x.IsAssigned).ToList();
        }

        public List<ImportDataField> GetAssigned()
        {
            return LstDataFields.Where(x => x.IsAssigned).ToList();
        }

        public void Assign(string friendlyName, int column)
        {
            foreach (var df in LstDataFields)
            {
                if (df.FriendlyName == friendlyName) df.Assign(column);
                else if (df.AssignedColHandle == column) df.Revoke();
            }
        }

        public void Unassign(string friendlyName)
        {
            foreach (var df in LstDataFields)
            {
                if (df.FriendlyName == friendlyName)
                {
                    df.Revoke();
                    break;
                }
            }
        }

        public void Unassign(int assignedColHandle)
        {
            foreach (var df in LstDataFields)
            {
                if (df.AssignedColHandle == assignedColHandle)
                {
                    df.Revoke();
                    break;
                }
            }
        }
        /// <summary>
        /// Checks that all required fields have been mapped to a column of data.
        /// </summary>
        /// <returns>A list of field names that are not valid.</returns>
        public virtual string Validate()
        {
            List<string> invalid = new List<string>();
            foreach (var df in LstDataFields)
                if (!df.Validate()) invalid.Add(df.FriendlyName);


            if (invalid.Count > 0)
            {
                return $"The following attributes are compulsory but have not been assigned to a column of data: {string.Join($"{Environment.NewLine}\t", invalid)}";
            }

            return String.Empty;
        }

        internal List<ImportDataField> GetValidateableFields()
        {
            return LstDataFields.Where(x => x.CustomRegisterId == null && x.ShouldValidate).ToList();
        }

        internal abstract void Audit();
    }
}
