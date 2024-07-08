using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SpendWise.Models;
using System.Threading.Tasks;
using SpendWise.ViewModels;
using Microsoft.AspNetCore.Authorization;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet("/Account/Login")] // GET dla /Account/Login
    public IActionResult Login()
    {
        return View(); // Renderuje widok formularza logowania
    }

    [HttpPost("/Account/Login")] // POST dla /Account/Login
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Przekierowanie po poprawnym zalogowaniu
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt."); // Dodaje błąd do ModelState
                return View(model); // Zwraca widok formularza logowania z błędami
            }
        }
        return View(model); // Zwraca widok formularza logowania z błędami
    }

    [HttpGet("/Account/Register")] // GET dla /Account/Register
    public IActionResult Register()
    {
        return View(); // Renderuje widok formularza rejestracji
    }

    [HttpPost("/Account/Register")] // POST dla /Account/Register
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home"); // Przekierowanie po poprawnej rejestracji
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description); // Dodaje błędy do ModelState
                }
                return View(model); // Zwraca widok formularza rejestracji z błędami
            }
        }
        return View(model); // Zwraca widok formularza rejestracji z błędami walidacji
    }

    [HttpPost("/Account/Logout")] // POST dla /Account/Logout
    [Authorize] // Tylko zalogowani użytkownicy mogą wykonać tę akcję
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync(); // Wylogowanie użytkownika
        return RedirectToAction("Index", "Home"); // Przekierowanie po wylogowaniu
    }
}
