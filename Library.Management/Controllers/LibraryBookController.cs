using Library.Management.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Library.Management.Controllers
{
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
				return View("Not found");
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

	}
}
