using Day9.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourProject.Models;

namespace Day9.Controllers
{
    [AllowAnonymous]
    [Route("Account/[action]")]
    public class AccountController : Controller
    {
        public UserManager<Client> UserManager { get; }
        public SignInManager<Client> SignInManager { get; }

        public AccountController(UserManager<Client> userManager, SignInManager<Client> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Register() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                Client userModel = new Client
                {
                    UserName = newUserVM.UserName,
                    Email = newUserVM.UserName,
                    FirstName = newUserVM.FirstName,
                    LastName = newUserVM.LastName,
                    Nationality = newUserVM.Nationality,    
                    EducationLevel = newUserVM.EducationLevel 
                };

                IdentityResult result = await UserManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(userModel, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public IActionResult Login() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(
                    newUserVM.UserName,
                    newUserVM.Password,
                    newUserVM.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}