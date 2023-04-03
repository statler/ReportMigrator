namespace cpModel.Interfaces
{
    public interface ILockableEntity
    {
        int? OptimisticLockField { get; set; }
    }
}
