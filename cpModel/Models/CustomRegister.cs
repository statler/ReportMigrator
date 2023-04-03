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
    public partial class CustomRegister: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int CustomRegisterId { get; set; }
        public string CustomRegisterName { get; set; }
        public int? ProjectId { get; set; }
        public string ShortCode { get; set; }
        public int? ValueTypeId { get; set; }
        public bool? IsAvailableLot { get; set; }
        public bool? IsAvailableCc { get; set; }
        public bool? IsAvailableNcr { get; set; }
        public bool? IsAvailableTr { get; set; }
        public bool? IsAvailableDaycost { get; set; }
        public bool? IsAvailableInvoice { get; set; }
        public bool? IsAvailableQty { get; set; }
        public bool? IsAvailableVrn { get; set; }
        public bool? IsAvailableCn { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsRequiredCc { get; set; }
        public bool? IsRequiredNcr { get; set; }
        public bool? IsRequiredTr { get; set; }
        public bool? IsRequiredDaycost { get; set; }
        public bool? IsRequiredInvoice { get; set; }
        public bool? IsRequiredQty { get; set; }
        public bool? IsRequiredVrn { get; set; }
        public bool? IsRequiredCn { get; set; }
        public decimal? OrderId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<CustomRegisterActivation> CustomRegisterActivations { get; set; }
        public virtual ICollection<CustomRegisterItem> CustomRegisterItems { get; set; }
        public virtual ICollection<CustomRegisterValue> CustomRegisterValues { get; set; }
        public virtual ICollection<LotMapSection> LotMapSections { get; set; }

        public virtual Project Project { get; set; }

        public CustomRegister()
        {
            CustomRegisterActivations = new HashSet<CustomRegisterActivation>();
            CustomRegisterItems = new HashSet<CustomRegisterItem>();
            CustomRegisterValues = new HashSet<CustomRegisterValue>();
            LotMapSections = new HashSet<LotMapSection>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
