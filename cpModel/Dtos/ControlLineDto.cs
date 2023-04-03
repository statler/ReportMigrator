﻿using cpModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public class ControlLineDto 
    {
        public int ControlLineId { get; set; }
        public string ControlLineName { get; set; }
        public string Description { get; set; }
        public string FirstLetter { get; set; }
    }
}
