using Microsoft.AspNetCore.Mvc;
using VehicleRentalUI.Models;
using VehicleRentalUI.Services;

namespace VehicleRentalUI.Controllers;

public class AdminController : Controller
{
    private readonly IVehicleRentalService _rentalService;

    public AdminController(IVehicleRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    public IActionResult Index()
    {
        var data = _rentalService.GetAdminDashboardData();
        return View(data);
    }

    public IActionResult Vehicles()
    {
        var vehicles = _rentalService.GetAllVehicles();
        return View(vehicles);
    }

    [HttpGet]
    public IActionResult AddVehicle()
    {
        return View(new Vehicle { Year = DateTime.Now.Year, DailyRate = 199, Seats = 5, FuelType = "Petrol", Transmission = "Automatic", Category = "Luxury" });
    }

    [HttpPost]
    public IActionResult AddVehicle(Vehicle vehicle)
    {
        if (string.IsNullOrWhiteSpace(vehicle.Make) || string.IsNullOrWhiteSpace(vehicle.Model))
        {
            ModelState.AddModelError("", "Make and Model are required.");
            return View(vehicle);
        }

        _rentalService.AddVehicle(vehicle);
        TempData["SuccessMessage"] = $"Successfully added {vehicle.FullName} to the fleet!";
        return RedirectToAction("Vehicles");
    }

    [HttpPost]
    public IActionResult ToggleAvailability(int id)
    {
        _rentalService.ToggleAvailability(id);
        TempData["SuccessMessage"] = "Vehicle availability updated.";
        return RedirectToAction("Vehicles");
    }

    [HttpPost]
    public IActionResult DeleteVehicle(int id)
    {
        var success = _rentalService.DeleteVehicle(id);
        if (success)
        {
            TempData["SuccessMessage"] = "Vehicle removed from fleet.";
        }
        else
        {
            TempData["ErrorMessage"] = "Could not delete vehicle.";
        }
        return RedirectToAction("Vehicles");
    }

    public IActionResult Bookings(string? status)
    {
        var bookings = _rentalService.GetAllBookings();
        if (!string.IsNullOrEmpty(status) && Enum.TryParse<BookingStatus>(status, true, out var parsedStatus))
        {
            bookings = bookings.Where(b => b.Status == parsedStatus).ToList();
        }

        ViewBag.SelectedStatus = status ?? "All";
        return View(bookings);
    }

    [HttpPost]
    public IActionResult UpdateBookingStatus(int id, BookingStatus status)
    {
        var success = _rentalService.UpdateBookingStatus(id, status);
        if (success)
        {
            TempData["SuccessMessage"] = $"Booking #{id} status updated to {status}.";
        }
        return RedirectToAction("Bookings");
    }

    public IActionResult Customers()
    {
        var customers = _rentalService.GetAllUsers().Where(u => u.Role == UserRole.Customer).ToList();
        return View(customers);
    }
}
