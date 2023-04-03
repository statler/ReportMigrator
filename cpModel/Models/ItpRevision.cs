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
    public partial class ItpRevision: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ItpRevisionId { get; set; }
        public int? ItpCurrentId { get; set; }
        public int? ItpSupersededId { get; set; }
        public string RevisionCommentary { get; set; }
        public int? BaseItpId { get; set; }
        public DateTime? DateRevision { get; set; }
        public string RevisionRef { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual Itp BaseItp { get; set; }
        public virtual Itp ItpCurrent { get; set; }
        public virtual Itp ItpSuperseded { get; set; }

        public ItpRevision()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
