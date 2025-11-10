
using LMS.Logic;
using LMS.Model;
using LMS.Services;
using System;
using System.Collections.Generic;

namespace LMS.Business
{
    public class BookBO : IBookService
    {
        public Tuple<bool, string> AddBook(BookModel bookmodel)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.AddBook(bookmodel);
            }

        }

        public Tuple<bool, string> RemoveBook(int id)
        {

            using (var bookLogic = new BookLogic())
            {
                return bookLogic.RemoveBook(id);
            }

        }

        public IEnumerable<BookModel> SearchByTitle(string title)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.SearchByTitle(title);
            }
        }


        public IEnumerable<BookModel> SearchByAuthor(string author)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.SearchByAuthor(author);
            }
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.GetAllBooks();
            }
        }
        public IEnumerable<BookModel> GetAllActiveBooks(bool active = true)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.GetAllActiveBooks(active);
            }
        }
        public BookModel GetBookByID(int id)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.GetBookByID(id);
            }
        }
        public Tuple<bool, string> Edit(int id, BookModel bookModel)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.Edit(id, bookModel);
            }
        }
        public Tuple<bool, string> Delete(int id)
        {
            using (var bookLogic = new BookLogic())
            {
                return bookLogic.Delete(id);
            }
        }

    }
}
