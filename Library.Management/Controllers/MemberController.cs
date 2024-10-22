using Library.Management.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Library.Management.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _MemberService;
        public MemberController(IMemberService MemberService)
        {
            _MemberService = MemberService;
            
        }
       public async Task<IActionResult> Index()
        {
            try
            {
                var memberList = await _MemberService.GetAllAsync();
                return View(memberList);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "An error occured while loading member list";
                return View("Error");
            }
        }
    }
}
