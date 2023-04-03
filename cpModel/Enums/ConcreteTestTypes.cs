using System;

namespace cpModel.Enums
{
    public enum ConcreteTestTypes
    {
        noTests = 0,
        fsDiff = 1,
        fs3xAnyLTfcft = 2,
        fsLT09fc = 4,
        fs3xLotGTfc = 8,
        fs3xLotLT14fc = 16,
        fsAnyLTfcft10week = 32,
        stdev = 64,
    }
}
