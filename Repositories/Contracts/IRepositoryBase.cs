using System.Linq.Expressions;

namespace Repositories.Contracts
{
    //Tüm sistemdeki entities için CRUD işlemlerinin genel yapısını belirleyen interface. Generic verildi çünkü o kısma istenen entity gelecek.
    public interface IRepositoryBase<T>
    {
        //CRUD METHODS
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}