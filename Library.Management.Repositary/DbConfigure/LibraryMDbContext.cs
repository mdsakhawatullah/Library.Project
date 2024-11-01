using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Management.Repositary.DbConfigure
{
	public class LibraryMDbContext : IdentityDbContext<ApplicationUser>
	{
		public LibraryMDbContext(DbContextOptions<LibraryMDbContext> options): base(options)
		{

		}

		public DbSet<LibraryBook> LibraryBooks { get; set; } 
		public DbSet<BorrowRecord> BorrowRecords { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		
	}
}
