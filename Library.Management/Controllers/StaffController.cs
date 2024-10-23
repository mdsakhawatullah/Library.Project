using Library.Management.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Library.Management.Controllers
{
	public class StaffController : Controller
	{
		private readonly IStaffService _StaffService;
        public StaffController(IStaffService StaffService)
        {
			_StaffService = StaffService;
            
        }
		//GET: Staff
        public async Task<IActionResult> Index()
		{
			try
			{
				var staffList = await _StaffService.GetAllAsync();
				return View(staffList);
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		}
		//GET: Staff/Details/2
		public async Task<IActionResult> Details(int? id)
		{
			if(id == null || id == 0)
			{
				TempData["ErrorMessage"] = "Staff id not provded";
				return View("Not Found");

			}
			try
			{
				var staff = await _StaffService.GetById(id.Value);
				return View(staff);
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		}
	}
}
