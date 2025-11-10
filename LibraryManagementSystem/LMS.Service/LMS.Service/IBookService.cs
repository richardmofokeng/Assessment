
using LMS.Model;
using System;
using System.Collections.Generic;

namespace LMS.Services
{
    public interface IBookService
    {
        Tuple<bool, string> AddBook(BookModel bookmodel);
        Tuple<bool, string> RemoveBook(int id);
        IEnumerable<BookModel> SearchByTitle(string title);
        IEnumerable<BookModel> SearchByAuthor(string author);
        IEnumerable<BookModel> GetAllBooks();
        IEnumerable<BookModel> GetAllActiveBooks(bool active = true);
        BookModel GetBookByID(int id);
        Tuple<bool, string> Edit(int id, BookModel bookModel);
        Tuple<bool, string> Delete(int id);

    }
}
