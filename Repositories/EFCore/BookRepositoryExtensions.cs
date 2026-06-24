using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.EFCore
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint MaxPrice) =>
        books.Where(book =>
            book.Price >= minPrice &&
            book.Price <= MaxPrice);
    }
}