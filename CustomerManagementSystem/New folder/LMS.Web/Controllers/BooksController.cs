using LMS.Business;
using LMS.Model;
using LMS.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace LMS.Web.Controllers
{
    public class BooksController : Controller
    {
        [Inject]
        private readonly  IBookService ibookService;
        public BooksController(IBookService _ibookService)
        {
            ibookService = _ibookService;
        }
       
      
        public ActionResult Index(string searchTitle = null, string searchAuthor = null)
        {
            if (!string.IsNullOrWhiteSpace(searchTitle))
            {
                var results =  ibookService.SearchByTitle(searchTitle);
                ViewData["SearchTitle"] = searchTitle;
                return View(results);
            }

            if (!string.IsNullOrWhiteSpace(searchAuthor))
            {
                var results =  ibookService.SearchByAuthor(searchAuthor);
                ViewData["SearchAuthor"] = searchAuthor;
                return View(results);
            }

            var all =  ibookService.GetAllActiveBooks(true);
            return View(all);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var book = (ibookService.GetAllBooks()).FirstOrDefault(b => b.Id == id);
            if (book == null)
                return View();
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookModel bookmodel)
        {
            try
            {
                if (!ModelState.IsValid) return View(bookmodel);

                 ibookService.AddBook(bookmodel);
                return RedirectToAction(nameof(Index));
                 
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var book = ibookService.GetBookByID(id);
            if (book == null)
                return View();
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookModel bookModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(bookModel);

                var results = ibookService.Edit(id, bookModel);
                if(results.Item1)
                         return RedirectToAction(nameof(Index));
                else
                    return View(bookModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var book = ibookService.GetBookByID(id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookModel bookModel)
        {
            try
            {
                // TODO: Add delete logic here
                var book = ibookService.GetBookByID(id);
                if (book != null)
                {
                    var results = ibookService.Delete(id);
                    if (results.Item1)
                        return RedirectToAction("Index");
                    else
                        return View(bookModel);
                }
                else
                {
                    return RedirectToAction("Index");
                }
               
            }
            catch
            {
                return View();
            }
        }
    }
}
