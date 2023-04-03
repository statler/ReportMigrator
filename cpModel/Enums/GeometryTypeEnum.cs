using System;
using System.Linq;

namespace cpModel.Enums
{
    // TODO: can remove Coord_Region 4, remapping old values to 3
    public enum GeometryTypeEnum
    {
        No_Geometry = 1,
        Chainage = 2,
        Coordinate = 3,
        Coord_Region = 4
    }
}
