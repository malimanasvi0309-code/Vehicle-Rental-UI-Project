using VehicleRentalUI.Models;

namespace VehicleRentalUI.Services;

public interface IVehicleRentalService
{
    List<Vehicle> GetAllVehicles();
    List<Vehicle> SearchVehicles(string? query, string? category, string? fuelType, string? transmission, decimal? maxPrice, string? sortBy);
    Vehicle? GetVehicleById(int id);
    void AddVehicle(Vehicle vehicle);
    void UpdateVehicle(Vehicle vehicle);
    bool DeleteVehicle(int id);
    void ToggleAvailability(int id);

    List<Booking> GetAllBookings();
    List<Booking> GetBookingsByCustomer(string email);
    Booking? GetBookingById(int id);
    Booking? GetBookingByReference(string reference);
    Booking CreateBooking(BookingCreateViewModel model);
    bool CancelBooking(int id);
    bool UpdateBookingStatus(int id, BookingStatus status);

    List<User> GetAllUsers();
    User? GetUserByEmail(string email);
    User? Authenticate(string email, string password);
    User Register(RegisterViewModel model);
    User? GetCurrentUser();
    void SetCurrentUser(string email);

    AdminDashboardViewModel GetAdminDashboardData();
}
