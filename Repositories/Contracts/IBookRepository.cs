using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    //Bu arayüz genel arayüzden miras alır. Amacı kendinden miras alacaklara hem generic T yapısını ilgili entitye ayarlamak hem metot isimlerini daha anlaşılır ve özel kılmak hem de değişmesi gereken metotları değiştirmek.
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);

    }
}