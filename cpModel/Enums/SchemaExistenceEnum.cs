using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum SchemaExistenceEnum
    {
        SchemaExists,
        DatabaseExists_NoSchema,
        ServerExists_NoDb,
        NotDetermined
    }
}
