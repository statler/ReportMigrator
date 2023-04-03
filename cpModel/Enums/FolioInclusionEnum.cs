using System;
using System.Linq;

namespace cpModel.Enums
{
    [Flags]
    public enum FolioFeatureInclusionEnum
    {
        DoNotInclude = 0,
        IncludeInDetailFolder = 1,
        Reg_SelectedDetailIds = 2,
        Reg_EntireRegister = 4
    }
}
