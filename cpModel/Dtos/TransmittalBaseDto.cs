using cpModel.Dtos.Template;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace cpModel.Dtos
{
    public partial class TransmittalBaseDto :  ILockableEntity
    {
        public int TransmittalId { get; set; }
        public int? TransmittalNo { get; set; }
        public string TransmittalRef { get; set; }
        public string Description { get; set; }
        public int? TransmittalTo { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? TransmittalDate { get; set; }
        public DateTime? DateConfirmed { get; set; }

        public int? OptimisticLockField { get; set; }
    }

}
