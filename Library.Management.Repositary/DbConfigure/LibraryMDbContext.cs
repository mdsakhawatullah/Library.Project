using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Management.Repositary.DbConfigure
{
	public class LibraryMDbContext : DbContext
	{
		public LibraryMDbContext(DbContextOptions<LibraryMDbContext> options): base(options)
		{

		}

		public DbSet<LibraryBook> LibraryBooks { get; set; }
		public DbSet<BorrowRecord> BorrowRecords { get; set; }

	}
}
