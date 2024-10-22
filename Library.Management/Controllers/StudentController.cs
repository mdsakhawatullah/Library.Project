using Library.Management.Service.InterfaceService;
using Library.Management.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Management.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentService _StudentService;
        public StudentController(IStudentService StudentService)
        {
			_StudentService = StudentService;
            
        }
        public async  Task<IActionResult> Index()
		{
			try
			{
				var studentList = await _StudentService.GetAllAsync();
				return View(studentList);
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = "An error occured when loading the student list";
				return View("Error");
			}
		}
	}
}
