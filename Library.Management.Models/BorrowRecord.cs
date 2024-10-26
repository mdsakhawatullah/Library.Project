using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Models
{
	public class BorrowRecord
	{
		[Key]
		public int BorrowRecordId { get; set; } //PK

		[Required]
		public int BookId { get; set; } //FK

		[Required(ErrorMessage = "Please enter Borrower Name")]
		public string BorrowerName { get; set; }

		[Required(ErrorMessage = "Please enter Borrower Email Address")]
		[EmailAddress(ErrorMessage = "Please enter a Email Address")]
		public string BorrowerEmail { get; set; }

		[Required(ErrorMessage ="Please provide borrower phone no")]
		[Phone(ErrorMessage = "Please Provide Valid Phone Number")]
		public string Phone { get; set; }


		
		[BindNever]
		[DataType(DataType.DateTime)]
		public DateTime BorrowDate { get; set; } = DateTime.UtcNow;

		[DataType(DataType.DateTime)]
		public DateTime? ReturnDate { get; set; }
		
		// navigation property
		[BindNever]
        [ForeignKey("BookId")] // Explicitly map BookId to LibraryBook's BookId
        public LibraryBook LibraryBook { get; set; }
	}
}
