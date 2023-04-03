using System;
using System.Linq;

namespace cpModel.Enums
{
    public enum SchemaValidationEnum
    {
        Connection_Ok,
        Schema_Init_Cancelled,
        Schema_Update_Required,
        Schema_Update_Cancelled,
        Schema_DatabaseExists_DiffSchema,
        Schema_Initialization_Error,
        SQLCe_Invalid_Version,
        SQLCe_DbBroken,
        SQLCe_Share_Error,
        SQLCe_Password_Error,
        IP_Block_Cleared,
        IP_Block_Not_Cleared,
        Undefined_Error,
        Could_not_connect_server
    }
}
