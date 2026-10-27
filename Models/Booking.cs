namespace VehicleRentalUI.Models;

public enum BookingStatus
{
    Pending,
    Confirmed,
    Active,
    Completed,
    Cancelled
}

public class Booking
{
    public int Id { get; set; }
    public string BookingReference { get; set; } = string.Empty;
    public int VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string PickupLocation { get; set; } = "Downtown Hub - Central Station";
    public string DropoffLocation { get; set; } = "Downtown Hub - Central Station";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalDays => Math.Max(1, (int)(EndDate.Date - StartDate.Date).TotalDays);
    public decimal DailyRate { get; set; }
    public decimal InsuranceFee { get; set; } = 1500m;
    public decimal ServiceFee { get; set; } = 1200m;
    public decimal TotalAmount => (DailyRate * TotalDays) + InsuranceFee + ServiceFee;
    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    public string PaymentMethod { get; set; } = "Credit Card (Visa •••• 4821)";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string SpecialRequests { get; set; } = string.Empty;
}
