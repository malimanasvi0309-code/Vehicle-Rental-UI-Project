namespace VehicleRentalUI.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // Luxury, Sports, SUV, Electric, Sedan
    public int Year { get; set; }
    public decimal DailyRate { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty; // Electric, Hybrid, Petrol, Diesel
    public string Transmission { get; set; } = string.Empty; // Automatic, Manual
    public int Seats { get; set; }
    public string Mileage { get; set; } = "Unlimited";
    public double Rating { get; set; } = 4.9;
    public int ReviewCount { get; set; } = 28;
    public bool IsAvailable { get; set; } = true;
    public string Description { get; set; } = string.Empty;
    public List<string> Features { get; set; } = new();
    public string LicensePlate { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public string FullName => $"{Year} {Make} {Model}";
}
