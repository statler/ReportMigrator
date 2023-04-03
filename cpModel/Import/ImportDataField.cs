using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpModel.Import
{
    public class ImportDataField
    {
        public string PropertyName { get; set; }
        public string FriendlyName { get; set; }
        public HashSet<string> Aliases { get; set; } = new HashSet<string>();
        public bool IsRequired { get; set; } = false;
        int _assignedColHandle = -1;
        public int? MaxLength { get; set; } = null;
        public int? CustomRegisterId { get; set; } = null;

        public bool IsAssigned => _assignedColHandle >= 0;
        public Type LookupType { get; set; } = null;
        public bool ShouldValidate { get; set; } = true;


        public ImportDataField(string propertyName, string friendlyName, bool isRequired)
        {
            PropertyName = propertyName;
            FriendlyName = friendlyName;
            IsRequired = isRequired;
            Aliases.Add(friendlyName);
        }
        public ImportDataField(string propertyName, string friendlyName, bool isRequired, int? maxLength)
            : this(propertyName, friendlyName, isRequired)
        {
            MaxLength = maxLength;
        }
        public ImportDataField(string propertyName, string friendlyName, bool isRequired, int? maxLength, Type lookupType)
            : this(propertyName, friendlyName, isRequired, maxLength)
        {
            LookupType = lookupType;
        }
        public ImportDataField(string propertyName, string friendlyName, HashSet<string> aliases, bool isRequired, int? maxLength, Type lookupType)
            : this(propertyName, friendlyName, isRequired, maxLength, lookupType)
        {
            Aliases = aliases;
        }

        public ImportDataField(string propertyName, string friendlyName, int customRegisterId)
            : this(propertyName, friendlyName, false)
        {
            CustomRegisterId = customRegisterId;
        }
        public ImportDataField(string propertyName, string friendlyName, HashSet<string> aliases, bool isRequired)
            : this(propertyName, friendlyName, isRequired)
        {
            Aliases = aliases;
        }
        public ImportDataField(string propertyName, string friendlyName, HashSet<string> aliases, bool isRequired, int maxLength)
            : this(propertyName, friendlyName, aliases, isRequired)
        {
            MaxLength = maxLength;
        }

        public void Revoke()
        {
            _assignedColHandle = -1;
        }

        public void Assign(int colHandle)
        {
            _assignedColHandle = colHandle;
        }

        public bool Validate()
        {
            return (IsRequired ? IsAssigned : true);
        }

        public int AssignedColHandle => _assignedColHandle;
    }
}
