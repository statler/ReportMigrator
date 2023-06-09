// <auto-generated>
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Models
{
    public partial class LogInfo: ILockableEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Exception { get; set; }
        public string LogEvent { get; set; }
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }
        public string UserName { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public LogInfo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

