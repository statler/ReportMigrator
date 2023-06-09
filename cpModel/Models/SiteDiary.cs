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
    public partial class SiteDiary: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int SiteDiaryId { get; set; }
        public int? SiteDiaryNo { get; set; }
        public int? ProjectId { get; set; }
        public int? DiaryById { get; set; }
        public DateTime? DiaryDate { get; set; }
        public string SiteActivityHtml { get; set; }
        public string Weather { get; set; }
        public decimal? HoursLost { get; set; }
        public decimal? PersonnelOnsite { get; set; }
        public decimal? HoursWorked { get; set; }
        public decimal? PersonnelOnsiteSubbies { get; set; }
        public decimal? HoursWorkedSubbies { get; set; }
        public DateTime? DateReviewed { get; set; }
        public int? ReviewedById { get; set; }
        public string ReviewCommentsHtml { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual ICollection<Instruction> Instructions { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<SiteDiaryCost> SiteDiaryCosts { get; set; }

        public virtual Project Project { get; set; }
        public virtual User DiaryBy { get; set; }
        public virtual User ReviewedBy { get; set; }

        public SiteDiary()
        {
            Incidents = new HashSet<Incident>();
            Instructions = new HashSet<Instruction>();
            Photos = new HashSet<Photo>();
            SiteDiaryCosts = new HashSet<SiteDiaryCost>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

