using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Management.Models;

namespace Library.Management.Repositary.InterfaceRepositary
{
	public interface ILibraryBookRepositary
	{
		Task <IEnumerable<LibraryBook>> GetAllAsync();
		Task<LibraryBook> GetByIdAsync(int id);
		Task AddAsync(LibraryBook entity);
		Task UpdateAsync(LibraryBook entity);
		Task<LibraryBook> GetEdit(int id);
		Task DeleteAsync(int id);
		Task<bool> BookExists(int id);
		
	}
}
