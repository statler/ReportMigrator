using cpModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Models
{
    public partial class TestRequest
    {
        public bool HasChainageData => ((ChStart ?? 0) != 0) || ((ChEnd ?? 0) != 0) || (ControlLineId != null);
    }
}
