using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.InterfaceService
{
	public interface ILibraryBookService
	{
		Task<IEnumerable<LibraryBook>> GetAllAsync();

		Task<LibraryBook> GetById(int id);

		Task AddAsync(LibraryBook entity);

		Task UpdateAsync(LibraryBook entity);

		Task DeleteAsync(int id);
	}
}
