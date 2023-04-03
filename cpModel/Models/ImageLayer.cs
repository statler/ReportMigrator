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
    public partial class ImageLayer: ITrackableEntity, IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsSoftDeleted { get; set; }
        public int ImageLayerId { get; set; }
        public string LayerName { get; set; }
        public int? ProjectId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public double? Opacity { get; set; }
        public double? Rotation { get; set; }
        public bool? IsVisible { get; set; }
        public DateTime? LayerDate { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDisabled { get; set; }
        public decimal? OrderId { get; set; }
        public int? FileStoreId { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<ImageLayerPoint> ImageLayerPoints { get; set; }

        public virtual FileStoreDoc FileStoreDoc { get; set; }
        public virtual Project Project { get; set; }

        public ImageLayer()
        {
            ImageLayerPoints = new HashSet<ImageLayerPoint>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
