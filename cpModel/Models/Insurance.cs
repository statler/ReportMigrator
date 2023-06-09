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
    public partial class Insurance: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int InsuranceId { get; set; }
        public int? ProjectId { get; set; }
        public int? InsuranceTypeId { get; set; }
        public decimal? InsuranceValue { get; set; }
        public DateTime? InsuranceExpiry { get; set; }
        public DateTime? InsuranceRequiredUntil { get; set; }
        public int? InsuranceKeyDateType { get; set; }
        public bool? InsuranceProvided { get; set; }
        public string Notes { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }
        public virtual KeyDateType KeyDateType { get; set; }
        public virtual Project Project { get; set; }

        public Insurance()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

