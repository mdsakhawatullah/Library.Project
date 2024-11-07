using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Models.BusinessModels
{
    public class MemberVM
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? FileName { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
