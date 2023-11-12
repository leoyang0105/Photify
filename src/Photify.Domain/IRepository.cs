namespace Photify.Domain;

public interface IRepository<T> where T : IEntity
{
    IUnitOfWork UnitOfWork { get; }
}
