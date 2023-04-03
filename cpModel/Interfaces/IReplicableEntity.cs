using System;

namespace cpModel.Interfaces
{
    public interface IReplicableEntity
    {
        Guid? UniqueId { get; set; }
        string HrId { get; set; }
    }
}
