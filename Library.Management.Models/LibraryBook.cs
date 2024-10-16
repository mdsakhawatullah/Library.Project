using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Library.Management.Models
{
	public class LibraryBook
	{
		[Key]
		[BindNever]
		public int BookId { get; set; }

		[Required(ErrorMessage ="This field is required.")]
		[StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "The Author field is required.")]
		[StringLength(50, ErrorMessage = "Author name cannot exceed 50 characters.")]
		public string Author { get; set; }

		[Required(ErrorMessage = "The ISBN field is required.")]
		[RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "ISBN must be in the format XXX-XXXXXXXXXX.")]
		public string ISBN { get; set; }

		[Required(ErrorMessage = "The Published Date field is required.")]
		[DataType(DataType.Date)]
		[Display(Name = "Published Date")]
		public DateTime PublishedDate { get; set; }

		[BindNever]
		public bool IsAvailable { get; set; } = true;

		
		[BindNever]
		public IEnumerable<BorrowRecord>? BorrowRecord { get; set; }

	}
}
