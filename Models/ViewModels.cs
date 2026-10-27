namespace VehicleRentalUI.Models;

public class SearchFilterViewModel
{
    public string? Query { get; set; }
    public string? Category { get; set; }
    public string? FuelType { get; set; }
    public string? Transmission { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? SortBy { get; set; } // price_asc, price_desc, rating, name
    public DateTime? PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? PickupLocation { get; set; }
    public List<Vehicle> Vehicles { get; set; } = new();
    public List<string> AvailableCategories { get; set; } = new();
}

public class BookingCreateViewModel
{
    public int VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string PickupLocation { get; set; } = "Downtown Luxury Showroom";
    public string DropoffLocation { get; set; } = "Downtown Luxury Showroom";
    public DateTime StartDate { get; set; } = DateTime.Today.AddDays(1);
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(4);
    public string InsuranceOption { get; set; } = "Comprehensive";
    public bool AddGps { get; set; } = true;
    public bool AddChildSeat { get; set; } = false;
    public bool AdditionalDriver { get; set; } = false;
    public string SpecialRequests { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = "Credit Card";
    public string CardNumber { get; set; } = "4242 •••• •••• 4242";
    public string CardHolder { get; set; } = "Alex Morgan";
    public string CardExpiry { get; set; } = "12/28";
    public string CardCvv { get; set; } = "888";
}

public class LoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = true;
}

public class RegisterViewModel
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string DriverLicenseNumber { get; set; } = string.Empty;
}

public class AdminDashboardViewModel
{
    public int TotalVehicles { get; set; }
    public int AvailableVehicles { get; set; }
    public int TotalBookings { get; set; }
    public int ActiveBookings { get; set; }
    public decimal TotalRevenue { get; set; }
    public int TotalCustomers { get; set; }
    public List<Booking> RecentBookings { get; set; } = new();
    public List<Vehicle> TopVehicles { get; set; } = new();
}
