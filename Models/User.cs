namespace VehicleRentalUI.Models;

public enum UserRole
{
    Customer,
    Admin
}

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Customer;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateTime MemberSince { get; set; } = DateTime.Now.AddMonths(-6);
    public int TotalRentals { get; set; } = 3;
    public string DriverLicenseNumber { get; set; } = "DL-9821447X";
}
