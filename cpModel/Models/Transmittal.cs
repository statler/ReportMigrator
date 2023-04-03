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
    public partial class Transmittal: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int TransmittalId { get; set; }
        public int? TransmittalNo { get; set; }
        public string TransmittalRef { get; set; }
        public string Description { get; set; }
        public int? TransmittalTo { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? TransmittalDate { get; set; }
        public DateTime? DateConfirmed { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<TransmittalEmail> TransmittalEmails { get; set; }
        public virtual ICollection<TransmittalItem> TransmittalItems { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }

        public Transmittal()
        {
            TransmittalEmails = new HashSet<TransmittalEmail>();
            TransmittalItems = new HashSet<TransmittalItem>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

