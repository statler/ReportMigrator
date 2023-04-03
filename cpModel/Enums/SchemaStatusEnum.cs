using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum SchemaStatusEnum
    {
        Schema_Ok,
        Database_Schema_Error,
        Database_Upgrade_Required,
        Database_v10_v11_Required,
        Database_v10_v11_NotPermitted,
        Application_Update_required
    }
}
