using Library.Management.Models;
using Library.Management.Repositary.DbConfigure;
using Library.Management.Repositary.InterfaceRepositary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Repositary.Repositary
{
	public class LibraryBookRepositary : ILibraryBookRepositary
	{
		private readonly LibraryMDbContext _context;

		public LibraryBookRepositary(LibraryMDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<LibraryBook>> GetAllAsync()
		{
			return await _context.LibraryBooks
				.Include(b => b.BorrowRecord)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<LibraryBook> GetByIdAsync(int id)
		{
			return await _context.LibraryBooks.FirstOrDefaultAsync(b => b.BookId == id);
		}

		public async Task AddAsync(LibraryBook entity)
		{
			_context.LibraryBooks.Add(entity);
			await _context.SaveChangesAsync();
			
		}
		public async Task<LibraryBook> GetEdit(int id)
		{
			return await _context.LibraryBooks.FirstOrDefaultAsync(b => b.BookId == id);
		}

		public async Task UpdateAsync(LibraryBook entity)
		{
			_context.LibraryBooks.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.LibraryBooks.FindAsync(id);
			if(entity != null)
			{
				_context.LibraryBooks.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}
