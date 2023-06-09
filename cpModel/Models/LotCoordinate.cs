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
    public partial class LotCoordinate: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int LotCoordinatesId { get; set; }
        public int? LotId { get; set; }
        public decimal? OrderId { get; set; }
        public decimal? Xcoord { get; set; }
        public decimal? Ycoord { get; set; }
        public decimal? Zcoord { get; set; }
        public int? ReferenceSystemTypeId { get; set; }
        public int? ControlLineId { get; set; }
        public string PositionTypeId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual ControlLine ControlLine { get; set; }
        public virtual Lot Lot { get; set; }

        public LotCoordinate()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

