using Library.Management.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using Library.Management.Models;


namespace Library.Management.Controllers
{
	public class BorrowController : Controller
	{
		private readonly ILibraryBookService _LibraryBookService;
		private readonly IBorrowBookService _BorrowBookService;
		public BorrowController(ILibraryBookService LibraryBookService, IBorrowBookService BorrowBookService)
		{
			_LibraryBookService = LibraryBookService;
			_BorrowBookService = BorrowBookService;
		}
		// GET: Borrow/Create/5
		public async Task<IActionResult> Create(int? id)
		{
			if (id == null || id == 0)
			{
				TempData["ErrorMessage"] = "Book Id not found for Borrowing.";
				return View("NotFound");
			}
			try
			{
				var book = await _LibraryBookService.GetById(id.Value);
				if (book == null)
				{
					TempData["ErrorMessage"] = $"No	Book Found With this Id: {id}";
					return View("NotFound");
				}
				if (!book.IsAvailable)
				{
					TempData["ErrorMessage"] = $"This book: {book.Title} is currently not available for borrowing.";
					return View("NotFound");
				}
				var borrowView = new BorrowView()
				{
					BookId = book.BookId,
					BookTitle = book.Title
				};
				return View(borrowView);


			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("NotFound");
			}
		}
		///<summary>
		///Processes the borrowing action, creates a BorrowRecord, updates the book's availability
		///</summary>
		// POST: Borrow/Create/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BorrowView borrowView)
		{
			if (!ModelState.IsValid)
			{
				return View(borrowView);
			}
			try
			{

				var book = await _LibraryBookService.GetById(borrowView.BookId);
				if ( book == null)
				{
					TempData["ErrorMessage"] = $"No Book Found with this Id: {book.BookId}";
					return View("NotFound");
				}
				if (!book.IsAvailable)
				{
					TempData["ErrorMessage"] = $"Book Title: {book.Title} is already Borrowed. ";
					return View("NotFound");
				}
				var borrowRecord = new BorrowRecord
				{
					BookId = book.BookId,
					BorrowerName = borrowView.BorrowerName,
					BorrowerEmail = borrowView.BorrowerEmail,
					Phone = borrowView.Phone,
					BorrowDate = DateTime.UtcNow
				};

				book.IsAvailable = false;
				await _BorrowBookService.BorrowAddAsync(borrowRecord);

				TempData["SuccessMessage"] = $"Successfully borrowed the book: {book.Title}.";

				return RedirectToAction("Index", "LibraryBook");
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("NotFound");
			}

		}

		// GET: Borrow/Return/5
		///<summary>
		/// Displays the return confirmation for a specific borrow record
		///</summary>

		public async Task<IActionResult> Return(int? id)
		{
			if (id == null || id == 0)
			{
				TempData["ErrorMessage"] = "Id was not provided for returning";
				return View("NotFound");
			}
			try
			{
				var returnModel = await _BorrowBookService.GetBorrowRecordForReturnAsync(id.Value);
				if(returnModel == null)
				{
					TempData["ErrorMessage"] = $"No book found for this id: {returnModel.BorrowRecordId}";
					return View("NotFound");
				}
				return View(returnModel);

			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("NotFound");
			}
		}

		// POST: Borrow/Return/5
		///<summary>
		///Processes the return action, updates the BorrowRecord with the return date, updates the book's availability
		///</summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Return(ReturnView model)
		{
			if(!ModelState.IsValid)
			{
				return View(model);
			}
			try
			{
				await _BorrowBookService.ReturnBookAsync(model.BorrowRecordId);
				return RedirectToAction("Index", "LibraryBook");
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View(model);
			}
		}
	}
}
