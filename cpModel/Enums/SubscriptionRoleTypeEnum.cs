using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Enums
{
    public enum SubscriptionRoleTypeEnum
    {
        None = 0,
        //An associate user is one whose roles on a subscription have no add,edit or admin_delete permissions
        //Their roles can be only view or any of the absolute permissions
        Associate = 1,
        //A Full user has one or more roles in the subscription where they have add, edit or admin_delete permissions.
        Full = 2
    }
}
