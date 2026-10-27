using Microsoft.AspNetCore.Mvc;
using VehicleRentalUI.Models;
using VehicleRentalUI.Services;

namespace VehicleRentalUI.Controllers;

public class BookingController : Controller
{
    private readonly IVehicleRentalService _rentalService;

    public BookingController(IVehicleRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpGet]
    public IActionResult Create(int vehicleId, DateTime? startDate, DateTime? endDate)
    {
        var vehicle = _rentalService.GetVehicleById(vehicleId);
        if (vehicle == null)
        {
            return RedirectToAction("Index", "Vehicle");
        }

        var currentUser = _rentalService.GetCurrentUser();

        var model = new BookingCreateViewModel
        {
            VehicleId = vehicle.Id,
            Vehicle = vehicle,
            CustomerName = currentUser?.FullName ?? "Alex Morgan",
            CustomerEmail = currentUser?.Email ?? "alex.morgan@example.com",
            CustomerPhone = currentUser?.Phone ?? "+1 (555) 349-8201",
            StartDate = startDate ?? DateTime.Today.AddDays(1),
            EndDate = endDate ?? DateTime.Today.AddDays(4),
            PickupLocation = "Downtown Luxury Showroom - 450 Grand Ave",
            DropoffLocation = "Downtown Luxury Showroom - 450 Grand Ave"
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(BookingCreateViewModel model)
    {
        var vehicle = _rentalService.GetVehicleById(model.VehicleId);
        if (vehicle == null)
        {
            return RedirectToAction("Index", "Vehicle");
        }

        if (model.EndDate <= model.StartDate)
        {
            ModelState.AddModelError("EndDate", "Return date must be after pick-up date.");
            model.Vehicle = vehicle;
            return View(model);
        }

        var booking = _rentalService.CreateBooking(model);
        TempData["SuccessMessage"] = $"Your booking for {vehicle.FullName} is confirmed!";
        return RedirectToAction("Confirmation", new { reference = booking.BookingReference });
    }

    [HttpGet]
    public IActionResult Confirmation(string reference)
    {
        var booking = _rentalService.GetBookingByReference(reference);
        if (booking == null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(booking);
    }

    [HttpGet]
    public IActionResult MyBookings()
    {
        var currentUser = _rentalService.GetCurrentUser();
        var email = currentUser?.Email ?? "alex.morgan@example.com";
        var bookings = _rentalService.GetBookingsByCustomer(email);

        ViewBag.CurrentUser = currentUser;
        return View(bookings);
    }

    [HttpPost]
    public IActionResult Cancel(int id)
    {
        var result = _rentalService.CancelBooking(id);
        if (result)
        {
            TempData["SuccessMessage"] = "Reservation cancelled successfully.";
        }
        else
        {
            TempData["ErrorMessage"] = "Could not cancel booking.";
        }

        return RedirectToAction("MyBookings");
    }
}
