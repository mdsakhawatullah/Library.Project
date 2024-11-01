using Library.Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Management.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if(result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "LibraryBook");
                    }
                    var msg = string.Empty;
                    foreach(var error in result.Errors)
                    {
                        msg = error.Description + "\n";
                    }
                    TempData["ErrorMessage"] = msg;
                    return RedirectToAction("Index", "LibraryBook");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("NotFound");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "LibraryBook/Index")
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, 
                        model.Password, model.RememberMe, lockoutOnFailure: false);
                    if(result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Successfully Logged In";
                        return RedirectToAction("Index","LibraryBook");
                    }

                }
                return View(model);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                TempData["SuccessMessage"] = "Successfully Logout";
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("NotFound");
            }
        }
    }
}
