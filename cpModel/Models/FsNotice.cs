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
    public partial class FsNotice: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int FsNoticeId { get; set; }
        public int? FsId { get; set; }
        public int? CnId { get; set; }
        public bool? InclNotice { get; set; }
        public bool? InclAtt { get; set; }
        public bool? InResponse { get; set; }
        public int? ResponseId { get; set; }
        public decimal? OrderId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual CnResponse CnResponse { get; set; }
        public virtual ContractNotice ContractNotice { get; set; }
        public virtual FileStoreDoc FileStoreDoc { get; set; }

        public FsNotice()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

