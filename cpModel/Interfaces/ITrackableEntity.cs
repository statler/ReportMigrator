using System;

namespace cpModel.Interfaces
{
    public interface ITrackableEntity
    {
        int? CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }

    }
}
