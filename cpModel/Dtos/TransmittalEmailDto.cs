// <auto-generated>
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Dtos
{
    public partial class TransmittalEmailDto
    {
        public int TransmittalEmailId { get; set; }
        public int? TransmittalId { get; set; }
        public int? EmailLogId { get; set; }
        public int? EmailLogNo { get; set; }
        public DateTime? EmailDate { get; set; }

        public int? TransmittalNumber { get; set; }
        public string EmailDescription => $"{EmailLogNo}: ({EmailDate:d})";
    }

}
// </auto-generated>

