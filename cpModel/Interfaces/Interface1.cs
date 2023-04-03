using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Interfaces
{
    public interface ILotDates
    {
        DateTime? DateConf { get; set; }
        DateTime? DateGuar { get; set; }
        DateTime? DateOpen { get; set; }
        DateTime? DateRejected { get; set; }
        DateTime? DateWorkSt { get; set; }
    }
}
