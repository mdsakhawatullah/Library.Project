﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Models
{
	public class ReturnView
	{
		[Required]
		public int BorrowRecordId { get; set; }
		[BindNever]
		public string? BookTitle { get; set; }
		[BindNever]
		public string? BorrowerName { get; set; }
		[BindNever]
		public DateTime? BorrowDate { get; set; }

	}
}
