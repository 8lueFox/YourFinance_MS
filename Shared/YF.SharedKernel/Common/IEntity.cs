namespace YF.SharedKernel.Common;

public interface IEntity<TId>
{
    TId Id { get; }
}
