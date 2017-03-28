using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Repository.Specials;

namespace SpecialApp.UnitOfWork
{
    public interface ISpecialUOW : IBaseUOW
    {
        ISpecialRepository SpecialRepository { get; }

        IRepository<T> GetRepository<T>() where T : class;
    }
}