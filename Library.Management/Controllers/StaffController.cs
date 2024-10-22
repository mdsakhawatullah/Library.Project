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
        public async Task<IActionResult> Index()
		{
			try
			{
				var staffList = await _StaffService.GetAllAsync();
				return View(staffList);
			}
			catch(Exception ex)
			{
				TempData["ErrorMessage"] = "An error occured while loading Staff List";
				return View("Error");
			}
		}
	}
}
