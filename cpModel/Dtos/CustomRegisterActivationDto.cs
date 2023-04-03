using cpModel.Interfaces;
using cpModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace cpModel.Dtos
{
    public class CustomRegisterActivationDto
    {
        public int CustomRegisterActivationId { get; set; }
        public int? CustomRegisterId { get; set; }
        public int? ActivatedRegisterId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsReported { get; set; }
    }
}
