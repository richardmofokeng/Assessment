
using Common;
using Entity;
using Framework.UnitOfWork;
using LMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace LMS.Logic
{
    public class BookLogic : IDisposable
    {
        private IUnitOfWork<LibraryDBEntities> _unitOfWork = null;
        public BookLogic()
        {
            _unitOfWork = new UnitOfWork<LibraryDBEntities>();
        }

        public Tuple<bool, string> AddBook(BookModel bookmodel)
        {
            try
            {
                Book book = new Book();
                DtoTools.CopyFields(bookmodel, book);
                _unitOfWork.BookRepository.Add(book);
                _unitOfWork.Save();
                return new Tuple<bool, string>(true, "Book added successfully ");

            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public Tuple<bool, string> RemoveBook(int id)
        {
            try
            {
                var book = _unitOfWork.BookRepository.GetById(id);
                if (book != null)
                {
                    book.Active = false;
                    _unitOfWork.Save();
                    return new Tuple<bool, string>(true, "Book removed successfully ");
                }
                else
                {
                    return new Tuple<bool, string>(true, "Book cannot be found");
                }
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public IEnumerable<BookModel> SearchByTitle(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {

                var book = _unitOfWork.BookRepository.GetAllQueryable(x => x.Title == title).ToList();
                List<BookModel> bookModel = new List<BookModel>();
                DtoTools.CopyAll(book, bookModel);
                return bookModel;
            }
            else
                return new List<BookModel>();
        }
        public BookModel GetBookByID(int id)
        {           

                var book = _unitOfWork.BookRepository.GetById(id);
                BookModel bookModel = new BookModel();
                DtoTools.CopyFields(book, bookModel);
                return bookModel;
            
        }

        public IEnumerable<BookModel> SearchByAuthor(string author)
        {
            if (!string.IsNullOrWhiteSpace(author))
            {

                var book = _unitOfWork.BookRepository.GetAllQueryable(x => x.Author == author).ToList();
                List<BookModel> bookModel = new List<BookModel>();
                DtoTools.CopyAll(book, bookModel);
                return bookModel;
            }
            else
                return new List<BookModel>();
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            var books = _unitOfWork.BookRepository.GetAll().ToList();
            List<BookModel> bookModel = new List<BookModel>();
            DtoTools.CopyAll(books, bookModel);
            return bookModel;
        }
        public IEnumerable<BookModel> GetAllActiveBooks(bool active)
        {
            var books = _unitOfWork.BookRepository.GetAllQueryable(x => x.Active == active).ToList();
            List<BookModel> bookModel = new List<BookModel>();
            DtoTools.CopyAll(books, bookModel);
            return bookModel;
        }
        public Tuple<bool, string> Edit(int id, BookModel bookModel)
        {

            var existingbook = _unitOfWork.BookRepository.GetById(id);
            if (existingbook != null)
            {
                DtoTools.CopyFields(bookModel, existingbook);
                 

                _unitOfWork.Save();
                return new Tuple<bool, string>(true, string.Empty);
            }
            else
            {
                return new Tuple<bool, string>(true, "Record could not be found");
            }

        }
        public Tuple<bool, string> Delete(int id)
        {
            var existingbook = _unitOfWork.BookRepository.GetById(id);
            if (existingbook != null)
            {
                try
                {
                    existingbook.Active = false;
                    _unitOfWork.BookRepository.Update(existingbook);                    

                    _unitOfWork.Save();
                    return new Tuple<bool, string>(true, string.Empty);
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, string>(false, ex.Message);
                }
            }
            else
            {
                return new Tuple<bool, string>(true, "Record could not be found");
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
                _unitOfWork = null;
            }
            // free native resources
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}