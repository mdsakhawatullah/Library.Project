using Library.Management.Models;
using Library.Management.Repositary.InterfaceRepositary;
using Library.Management.Service.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.Service
{
	public class LibraryBookService : ILibraryBookService
	{
		private ILibraryBookRepositary _LibraryBookRepositary;
		public LibraryBookService(ILibraryBookRepositary LibraryBookRepositary)
		{
			_LibraryBookRepositary = LibraryBookRepositary;
		}

		public Task<IEnumerable<LibraryBook>> GetAllAsync()
		{
			return _LibraryBookRepositary.GetAllAsync();
		}

		public Task<LibraryBook> GetById(int id)
		{
			var book = _LibraryBookRepositary.GetByIdAsync(id);
			if(book == null)
			{
				throw new Exception($"No book found for this {id}");
			}
			return book;
		}

		public Task AddAsync(LibraryBook entity)
		{
			return _LibraryBookRepositary.AddAsync(entity);
		}

		public Task UpdateAsync(LibraryBook entity)
		{
			
            return _LibraryBookRepositary.UpdateAsync(entity);
			
		}
		public Task<LibraryBook> GetEdit(int id)
		{
			var book = _LibraryBookRepositary.GetEdit(id);
			if(book == null)
			{
				throw new Exception("No Book id found");
			
			}
			return book;
		}

		public Task DeleteAsync(int id)
		{
			return _LibraryBookRepositary.DeleteAsync(id);
		}
		public Task<bool> BookExists(int id)
		{
			return _LibraryBookRepositary.BookExists(id);
		}



	}
}
