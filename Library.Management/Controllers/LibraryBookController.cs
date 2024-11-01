using Library.Management.Models;
using Library.Management.Service.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Library.Management.Controllers
{
	[Authorize]
	public class LibraryBookController : Controller
	{
		private readonly ILibraryBookService _LibraryBookService;

		public LibraryBookController(ILibraryBookService LibraryBookService)
		{
			_LibraryBookService = LibraryBookService;
		}

		// GET: Books
		public async Task<IActionResult> Index()
		{
			try
			{
				var list = await _LibraryBookService.GetAllAsync();
				return View(list);

			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "An error occured when loading the books.";
				return View("Error");
			}

		}

		//GET: Books/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || id==0)
			{
				TempData["ErrorMessage"] = "Book id was not provided";
				return View("NotFound");
			}
			try
			{
				var book = await _LibraryBookService.GetById(id.Value);
				return View(book);
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		}

        // GET: Books/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Books/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(LibraryBook libraryBook)
		{
			if(ModelState.IsValid)
			{
				try
				{
					await _LibraryBookService.AddAsync(libraryBook);
					TempData["SuccessMessage"] = $"Successfully added this book: {libraryBook.Title}";
					return RedirectToAction("Index");
				}
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while adding the book.";
                    return View(libraryBook);
                }
            }
			return View(libraryBook);
			
		}

        // GET: Books/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if(id==null || id==0)
			{
                TempData["ErrorMessage"] = "Book ID was not provided for editing.";
                return View("NotFound");
            }
			try
			{
				var book = await _LibraryBookService.GetEdit(id.Value);
				return View(book);
			}
			catch(Exception ex)
			{
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
		}

		// POST: Books/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, LibraryBook libraryBook)
		{
            libraryBook.BookId = id;
            if (ModelState.IsValid)
			{
				try
				{
					await _LibraryBookService.UpdateAsync(libraryBook);
					TempData["SuccessMessage"] = $"Successfully updated the book: {libraryBook.Title}";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View("Error");
                }
            }
			return View(libraryBook);
		}
        // GET: Books/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if(id == null || id == 0)
			{
				TempData["ErrorMessage"] = "An error occured while deleting the id";
				return View("NotFound");
			}
			try
			{
				var libraryBook = await _LibraryBookService.GetById(id.Value);
				if(libraryBook == null)
				{
					TempData["ErrorMessage"] = $"Not Found this book for this {id}";
					return View("NotFound");
				}
				return View(libraryBook);
			}
			catch(Exception ex)
			{

                TempData["ErrorMessage"] = ex.Message;
				return View("Error");
            }
		}

		// POST: Books/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var book = await _LibraryBookService.GetById(id);
                if (book == null)
                {
                    TempData["ErrorMessage"] = "Book not found.";
                    return RedirectToAction("Index");
                }
                await _LibraryBookService.DeleteAsync(id);
				TempData["SuccessMessage"] = $"Successfully deleted this book: {book.Title}";

				return RedirectToAction("Index");
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		}

		private async Task<bool> LibraryBookExists(int id)
		{
			return await _LibraryBookService.BookExists(id);
		}

    }
}
