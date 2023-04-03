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
    public partial class CpDocument: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string Description { get; set; }
        public string DocGroup { get; set; }
        public string DocType { get; set; }
        public int? ProjectId { get; set; }
        public string ControlledBy { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? DateReceived { get; set; }
        public string ExtReference { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<CnControlledDoc> CnControlledDocs { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }
        public virtual ICollection<FsDoc> FsDocs { get; set; }
        public virtual ICollection<NcrDocument> NcrDocuments { get; set; }
        public virtual ICollection<Revision> Revisions { get; set; }
        public virtual ICollection<TransmittalItem> TransmittalItems { get; set; }

        public virtual Project Project { get; set; }

        public CpDocument()
        {
            CnControlledDocs = new HashSet<CnControlledDoc>();
            Distributions = new HashSet<Distribution>();
            FsDocs = new HashSet<FsDoc>();
            NcrDocuments = new HashSet<NcrDocument>();
            Revisions = new HashSet<Revision>();
            TransmittalItems = new HashSet<TransmittalItem>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
