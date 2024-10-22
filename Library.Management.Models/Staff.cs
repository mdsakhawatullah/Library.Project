using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Models
{
	public class Staff
	{
		[Key]
		public int StaffId { get; set; }
		public string StaffName { get; set; }
		public string Gender { get; set; }
		public DateTime JoinOfDate { get; set; }
		[NotMapped]
		public IFormFile UploadedFile { get; set; }
		public string? FileName { get; set; }
	}
}
