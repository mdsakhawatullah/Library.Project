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
		//GET: Studnets
        public async  Task<IActionResult> Index()
		{
			try
			{
				var studentList = await _StudentService.GetAllAsync();
				return View(studentList);
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		}
		//GET: Studnets/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if(id == null || id== 0)
			{
				TempData["ErrorMessage"] = "An error occured while loading information";
				return View("Error");
			}
			try
			{
				var student = await _StudentService.GetById(id.Value);
				return View(student);
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		}
	}
}
