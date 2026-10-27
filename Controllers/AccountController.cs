using Microsoft.AspNetCore.Mvc;
using VehicleRentalUI.Models;
using VehicleRentalUI.Services;

namespace VehicleRentalUI.Controllers;

public class AccountController : Controller
{
    private readonly IVehicleRentalService _rentalService;

    public AccountController(IVehicleRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model, string? returnUrl)
    {
        var user = _rentalService.Authenticate(model.Email, model.Password);
        if (user != null)
        {
            TempData["SuccessMessage"] = $"Welcome back, {user.FullName}!";
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            if (user.Role == UserRole.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid email or password. You can use the quick demo login buttons below.");
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
            return View(model);
        }

        var existing = _rentalService.GetUserByEmail(model.Email);
        if (existing != null)
        {
            ModelState.AddModelError("Email", "An account with this email already exists.");
            return View(model);
        }

        var user = _rentalService.Register(model);
        TempData["SuccessMessage"] = $"Account created! Welcome to Elite Drive, {user.FullName}.";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Profile()
    {
        var user = _rentalService.GetCurrentUser();
        if (user == null)
        {
            return RedirectToAction("Login");
        }

        ViewBag.Bookings = _rentalService.GetBookingsByCustomer(user.Email);
        return View(user);
    }

    [HttpGet]
    public IActionResult SwitchRole(string email)
    {
        _rentalService.SetCurrentUser(email);
        var user = _rentalService.GetCurrentUser();
        TempData["SuccessMessage"] = $"Switched profile to: {user?.FullName} ({(user?.Role == UserRole.Admin ? "Admin" : "Customer")})";

        if (user?.Role == UserRole.Admin)
        {
            return RedirectToAction("Index", "Admin");
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        TempData["SuccessMessage"] = "You have been logged out.";
        return RedirectToAction("Index", "Home");
    }
}
