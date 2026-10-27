using Microsoft.AspNetCore.Mvc;
using VehicleRentalUI.Models;
using VehicleRentalUI.Services;

namespace VehicleRentalUI.Controllers;

public class VehicleController : Controller
{
    private readonly IVehicleRentalService _rentalService;

    public VehicleController(IVehicleRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    public IActionResult Index(string? query, string? category, string? fuelType, string? transmission, decimal? maxPrice, string? sortBy)
    {
        var allVehicles = _rentalService.GetAllVehicles();
        var filtered = _rentalService.SearchVehicles(query, category, fuelType, transmission, maxPrice, sortBy);

        var model = new SearchFilterViewModel
        {
            Query = query,
            Category = category ?? "All",
            FuelType = fuelType ?? "All",
            Transmission = transmission ?? "All",
            MaxPrice = maxPrice,
            SortBy = sortBy ?? "rating",
            Vehicles = filtered,
            AvailableCategories = allVehicles.Select(v => v.Category).Distinct().ToList()
        };

        return View(model);
    }

    public IActionResult Details(int id)
    {
        var vehicle = _rentalService.GetVehicleById(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        ViewBag.RelatedVehicles = _rentalService.GetAllVehicles()
            .Where(v => v.Id != id && v.Category == vehicle.Category)
            .Take(3)
            .ToList();

        return View(vehicle);
    }
}
