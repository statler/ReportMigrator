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
    public partial class FsSurvey: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int FsSurveyId { get; set; }
        public int? FsId { get; set; }
        public int? SurveyId { get; set; }
        public decimal? OrderId { get; set; }
        public int? Status { get; set; }
        public int? NcrId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        public virtual FileStoreDoc FileStoreDoc { get; set; }
        public virtual Ncr Ncr { get; set; }
        public virtual SurveyRequest SurveyRequest { get; set; }

        public FsSurvey()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

