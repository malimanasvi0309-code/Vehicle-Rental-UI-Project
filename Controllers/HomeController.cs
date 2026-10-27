using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VehicleRentalUI.Models;
using VehicleRentalUI.Services;

namespace VehicleRentalUI.Controllers;

public class HomeController : Controller
{
    private readonly IVehicleRentalService _rentalService;

    public HomeController(IVehicleRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    public IActionResult Index()
    {
        var allVehicles = _rentalService.GetAllVehicles();
        ViewBag.FeaturedVehicles = allVehicles.Take(6).ToList();
        ViewBag.Categories = allVehicles.Select(v => v.Category).Distinct().ToList();
        ViewBag.CurrentUser = _rentalService.GetCurrentUser();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
