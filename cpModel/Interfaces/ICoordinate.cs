using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Interfaces
{
    public interface ICoordinate
    {
        decimal? Xcoord { get; set; }
        decimal? Ycoord { get; set; }
        decimal? Zcoord { get; set; }
    }
}
