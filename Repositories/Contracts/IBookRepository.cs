using Entities.Models;

namespace Repositories.Contracts
{
    //Bu arayüz genel arayüzden miras alır. Amacı kendinden miras alacaklara hem generic T yapısını ilgili entitye ayarlamak hem metot isimlerini daha anlaşılır ve özel kılmak hem de değişmesi gereken metotları değiştirmek.
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IQueryable<Book> GetAllBooks(bool trackChanges);
        Book GetOneBookById(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);

    }
}