//Expression içindeki <Func<T,bool> yapısını sql sorgusuna çevirecek olan yapı.
using System.Linq.Expressions;
//ORM EF Core veritabanı özelliklerini kullanabilme. AsNoTracking()
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    //Genel CRUD işlemlerinin içerikleri. Dikkat bu eklenecek olan Entitye göre değişebilir olduğundan en genel CRUD işlemlerini tanımlar.
    //where T: Class veritabanındaki tablolar sınıf olduğu için referans tipli veriler girebilir diye sınır çekmiş olduk.
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        // Miras alanlar veritabanı contextini kullanabilsin diye protected ve ve sadece bu ctorda değeri verilebilsin diye readonly kullanıldı. 
        protected readonly RepositoryContext _context;

        // Abstract sınıflar newlenemez. Ancak ondan miras alan somut sınıflar newlendiğinde,abstract sınıfın çalışabilmesi için onun ctor'unun beklediği bağımlılıkları (RepositoryContext) yukarıya (base sınıfına) göndermek zorundadır.
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges
        ? _context.Set<T>().AsNoTracking()
        : _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges
        ? _context.Set<T>().Where(expression).AsNoTracking()
        : _context.Set<T>().Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}