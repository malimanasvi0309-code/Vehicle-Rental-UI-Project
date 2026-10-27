using VehicleRentalUI.Models;

namespace VehicleRentalUI.Services;

public class VehicleRentalService : IVehicleRentalService
{
    private readonly List<Vehicle> _vehicles = new();
    private readonly List<Booking> _bookings = new();
    private readonly List<User> _users = new();
    private string _currentEmail = "alex.morgan@example.com"; // Default customer

    public VehicleRentalService()
    {
        SeedUsers();
        SeedVehicles();
        SeedBookings();
    }

    private void SeedUsers()
    {
        _users.Add(new User
        {
            Id = 1,
            FullName = "Alex Morgan",
            Email = "alex.morgan@example.com",
            Password = "password123",
            Phone = "+1 (555) 349-8201",
            Role = UserRole.Customer,
            AvatarUrl = "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=200&auto=format&fit=crop&q=80",
            MemberSince = DateTime.Now.AddMonths(-8),
            TotalRentals = 4,
            DriverLicenseNumber = "DL-CA-9281744"
        });

        _users.Add(new User
        {
            Id = 2,
            FullName = "Elena Vance (Admin)",
            Email = "admin@vehiclerental.com",
            Password = "adminpassword",
            Phone = "+1 (555) 890-1122",
            Role = UserRole.Admin,
            AvatarUrl = "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?w=200&auto=format&fit=crop&q=80",
            MemberSince = DateTime.Now.AddYears(-2),
            TotalRentals = 12,
            DriverLicenseNumber = "DL-NY-1029384"
        });

        _users.Add(new User
        {
            Id = 3,
            FullName = "Marcus Sterling",
            Email = "marcus.s@luxury.io",
            Password = "password123",
            Phone = "+1 (555) 671-9920",
            Role = UserRole.Customer,
            AvatarUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=200&auto=format&fit=crop&q=80",
            MemberSince = DateTime.Now.AddMonths(-3),
            TotalRentals = 2,
            DriverLicenseNumber = "DL-TX-4491023"
        });
    }

    private void SeedVehicles()
    {
        _vehicles.AddRange(new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Make = "Porsche",
                Model = "911 Carrera S",
                Category = "Sports",
                Year = 2025,
                DailyRate = 25000,
                ImageUrl = "https://images.unsplash.com/photo-1614162692292-7ac56d7f7f1e?w=800&auto=format&fit=crop&q=80",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Seats = 2,
                Mileage = "Unlimited",
                Rating = 4.98,
                ReviewCount = 42,
                IsAvailable = true,
                Description = "The iconic rear-engine sports car delivering twin-turbo performance, precision PDK shifting, and an unforgettable driving experience.",
                Features = new List<string> { "Sport Chrono Package", "BOSE Surround Audio", "Adaptive Cruise", "Apple CarPlay", "Carbon Ceramic Brakes" },
                LicensePlate = "POR-911-S",
                Color = "Agate Grey Metallic"
            },
            new Vehicle
            {
                Id = 2,
                Make = "Tesla",
                Model = "Model S Plaid",
                Category = "Electric",
                Year = 2024,
                DailyRate = 18500,
                ImageUrl = "https://images.unsplash.com/photo-1560958089-b8a1929cea89?w=800&auto=format&fit=crop&q=80",
                FuelType = "Electric",
                Transmission = "Automatic",
                Seats = 5,
                Mileage = "Unlimited",
                Rating = 4.95,
                ReviewCount = 67,
                IsAvailable = true,
                Description = "1,020 horsepower tri-motor all-wheel drive capable of 0-60 in 1.99s. Full Self-Driving capability and a premium executive cabin.",
                Features = new List<string> { "Tri-Motor AWD", "Autopilot & FSD", "Gaming Console", "Yoke Steering", "Panoramic Glass Roof" },
                LicensePlate = "TSL-PLD-01",
                Color = "Deep Blue Metallic"
            },
            new Vehicle
            {
                Id = 3,
                Make = "Mercedes-Benz",
                Model = "G 63 AMG",
                Category = "Luxury",
                Year = 2024,
                DailyRate = 32000,
                ImageUrl = "https://images.unsplash.com/photo-1520031441872-265e4ff70366?w=800&auto=format&fit=crop&q=80",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Seats = 5,
                Mileage = "Unlimited",
                Rating = 4.92,
                ReviewCount = 38,
                IsAvailable = true,
                Description = "Handcrafted 4.0L V8 biturbo engine with unmistakable presence, side exhaust roar, and ultra-plush diamond-stitched Nappa leather interior.",
                Features = new List<string> { "AMG Night Package", "Burmester 3D Sound", "3 Differential Locks", "Massaging Seats", "360 Surround View" },
                LicensePlate = "AMG-G63-07",
                Color = "Obsidian Black"
            },
            new Vehicle
            {
                Id = 4,
                Make = "Range Rover",
                Model = "Sport Autobiography",
                Category = "SUV",
                Year = 2025,
                DailyRate = 16500,
                ImageUrl = "https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=800&auto=format&fit=crop&q=80",
                FuelType = "Hybrid",
                Transmission = "Automatic",
                Seats = 7,
                Mileage = "Unlimited",
                Rating = 4.89,
                ReviewCount = 31,
                IsAvailable = true,
                Description = "Dynamic luxury SUV combining off-road dominance with serene whisper-quiet cabin acoustics, Meridian sound, and panoramic sky view.",
                Features = new List<string> { "Air Suspension", "Heated & Cooled Seats", "Terrain Response 2", "Head-Up Display", "Wireless Charging" },
                LicensePlate = "RR-SPT-88",
                Color = "Santorini Black"
            },
            new Vehicle
            {
                Id = 5,
                Make = "BMW",
                Model = "M4 Competition Coupe",
                Category = "Sports",
                Year = 2024,
                DailyRate = 15000,
                ImageUrl = "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800&auto=format&fit=crop&q=80",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Seats = 4,
                Mileage = "Unlimited",
                Rating = 4.91,
                ReviewCount = 54,
                IsAvailable = true,
                Description = "503 hp M TwinPower Turbo inline 6-cylinder engineered for pure adrenaline, aggressive aerodynamics, and track-ready steering response.",
                Features = new List<string> { "M xDrive System", "Carbon Bucket Seats", "Harman Kardon Audio", "Active M Differential", "Laserlight Headlights" },
                LicensePlate = "BMW-M4C-12",
                Color = "Isle of Man Green"
            },
            new Vehicle
            {
                Id = 6,
                Make = "Audi",
                Model = "RS e-tron GT",
                Category = "Electric",
                Year = 2025,
                DailyRate = 19500,
                ImageUrl = "https://images.unsplash.com/photo-1603584173870-7f23fdae1b7a?w=800&auto=format&fit=crop&q=80",
                FuelType = "Electric",
                Transmission = "Automatic",
                Seats = 4,
                Mileage = "Unlimited",
                Rating = 4.96,
                ReviewCount = 29,
                IsAvailable = true,
                Description = "Electric grand tourer sculpted for aerodynamics, featuring 800V ultra-fast charging, quattro all-wheel drive, and futuristic luxury interior.",
                Features = new List<string> { "quattro Electric AWD", "Bang & Olufsen 3D", "Matrix LED Lasers", "Adaptive Air Suspension", "Thermal Pre-Conditioning" },
                LicensePlate = "AUD-EGT-99",
                Color = "Daytona Grey"
            },
            new Vehicle
            {
                Id = 7,
                Make = "Ford",
                Model = "Mustang Dark Horse",
                Category = "Sports",
                Year = 2024,
                DailyRate = 12000,
                ImageUrl = "https://images.unsplash.com/photo-1584345604476-8ec5e12e42dd?w=800&auto=format&fit=crop&q=80",
                FuelType = "Petrol",
                Transmission = "Manual",
                Seats = 4,
                Mileage = "Unlimited",
                Rating = 4.88,
                ReviewCount = 45,
                IsAvailable = false,
                Description = "500 hp 5.0L Coyote V8 powerhouse with active valve performance exhaust, MagneRide damping, and raw American muscle heritage.",
                Features = new List<string> { "Tremec 6-Speed Manual", "Active Valve Exhaust", "Brembo 6-Piston Brakes", "SYNC 4 Infotainment", "Launch Control" },
                LicensePlate = "MST-DRK-50",
                Color = "Blue Ember Metallic"
            },
            new Vehicle
            {
                Id = 8,
                Make = "Genesis",
                Model = "G90 Luxury Sedan",
                Category = "Sedan",
                Year = 2025,
                DailyRate = 14000,
                ImageUrl = "https://images.unsplash.com/photo-1550355291-bbee04a92027?w=800&auto=format&fit=crop&q=80",
                FuelType = "Hybrid",
                Transmission = "Automatic",
                Seats = 5,
                Mileage = "Unlimited",
                Rating = 4.94,
                ReviewCount = 22,
                IsAvailable = true,
                Description = "Flagship executive sedan with VIP reclining rear lounge seats, fragrance system, massage functions, and effortless twin-turbo power.",
                Features = new List<string> { "VIP Executive Lounge", "Bang & Olufsen Premier", "Rear Wheel Steering", "EasyClose Power Doors", "Active Noise Cancellation" },
                LicensePlate = "GEN-G90-44",
                Color = "Uyuni White"
            }
        });
    }

    private void SeedBookings()
    {
        var car1 = _vehicles.First(v => v.Id == 1);
        var car2 = _vehicles.First(v => v.Id == 2);
        var car3 = _vehicles.First(v => v.Id == 3);

        _bookings.Add(new Booking
        {
            Id = 1,
            BookingReference = "VR-984210",
            VehicleId = car2.Id,
            Vehicle = car2,
            CustomerName = "Alex Morgan",
            CustomerEmail = "alex.morgan@example.com",
            CustomerPhone = "+1 (555) 349-8201",
            PickupLocation = "Downtown Luxury Showroom",
            DropoffLocation = "International Airport Terminal 3",
            StartDate = DateTime.Today.AddDays(2),
            EndDate = DateTime.Today.AddDays(5),
            DailyRate = car2.DailyRate,
            InsuranceFee = 2500m,
            ServiceFee = 1500m,
            Status = BookingStatus.Confirmed,
            PaymentMethod = "Mastercard •••• 9920",
            CreatedAt = DateTime.Now.AddDays(-2)
        });

        _bookings.Add(new Booking
        {
            Id = 2,
            BookingReference = "VR-774102",
            VehicleId = car1.Id,
            Vehicle = car1,
            CustomerName = "Alex Morgan",
            CustomerEmail = "alex.morgan@example.com",
            CustomerPhone = "+1 (555) 349-8201",
            PickupLocation = "Sunset Coast Marina",
            DropoffLocation = "Sunset Coast Marina",
            StartDate = DateTime.Today.AddDays(-10),
            EndDate = DateTime.Today.AddDays(-7),
            DailyRate = car1.DailyRate,
            InsuranceFee = 2500m,
            ServiceFee = 1500m,
            Status = BookingStatus.Completed,
            PaymentMethod = "Visa •••• 4821",
            CreatedAt = DateTime.Now.AddDays(-12)
        });

        _bookings.Add(new Booking
        {
            Id = 3,
            BookingReference = "VR-332901",
            VehicleId = car3.Id,
            Vehicle = car3,
            CustomerName = "Marcus Sterling",
            CustomerEmail = "marcus.s@luxury.io",
            CustomerPhone = "+1 (555) 671-9920",
            PickupLocation = "Executive Airport Hangar",
            DropoffLocation = "Executive Airport Hangar",
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(7),
            DailyRate = car3.DailyRate,
            InsuranceFee = 3500m,
            ServiceFee = 2000m,
            Status = BookingStatus.Active,
            PaymentMethod = "Amex Centurion •••• 1004",
            CreatedAt = DateTime.Now.AddDays(-1)
        });
    }

    public List<Vehicle> GetAllVehicles()
    {
        return _vehicles.OrderByDescending(v => v.Rating).ToList();
    }

    public List<Vehicle> SearchVehicles(string? query, string? category, string? fuelType, string? transmission, decimal? maxPrice, string? sortBy)
    {
        var result = _vehicles.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(query))
        {
            var q = query.Trim().ToLower();
            result = result.Where(v =>
                v.Make.ToLower().Contains(q) ||
                v.Model.ToLower().Contains(q) ||
                v.Category.ToLower().Contains(q) ||
                v.Features.Any(f => f.ToLower().Contains(q)));
        }

        if (!string.IsNullOrWhiteSpace(category) && category != "All")
        {
            result = result.Where(v => v.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(fuelType) && fuelType != "All")
        {
            result = result.Where(v => v.FuelType.Equals(fuelType, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(transmission) && transmission != "All")
        {
            result = result.Where(v => v.Transmission.Equals(transmission, StringComparison.OrdinalIgnoreCase));
        }

        if (maxPrice.HasValue && maxPrice.Value > 0)
        {
            result = result.Where(v => v.DailyRate <= maxPrice.Value);
        }

        result = sortBy switch
        {
            "price_asc" => result.OrderBy(v => v.DailyRate),
            "price_desc" => result.OrderByDescending(v => v.DailyRate),
            "rating" => result.OrderByDescending(v => v.Rating),
            "year" => result.OrderByDescending(v => v.Year),
            _ => result.OrderByDescending(v => v.Rating)
        };

        return result.ToList();
    }

    public Vehicle? GetVehicleById(int id)
    {
        return _vehicles.FirstOrDefault(v => v.Id == id);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicle.Id = _vehicles.Any() ? _vehicles.Max(v => v.Id) + 1 : 1;
        if (string.IsNullOrWhiteSpace(vehicle.ImageUrl))
        {
            vehicle.ImageUrl = "https://images.unsplash.com/photo-1542282088-72c9c27ed0cd?w=800&auto=format&fit=crop&q=80";
        }
        _vehicles.Add(vehicle);
    }

    public void UpdateVehicle(Vehicle vehicle)
    {
        var existing = _vehicles.FirstOrDefault(v => v.Id == vehicle.Id);
        if (existing != null)
        {
            existing.Make = vehicle.Make;
            existing.Model = vehicle.Model;
            existing.Category = vehicle.Category;
            existing.Year = vehicle.Year;
            existing.DailyRate = vehicle.DailyRate;
            existing.ImageUrl = vehicle.ImageUrl;
            existing.FuelType = vehicle.FuelType;
            existing.Transmission = vehicle.Transmission;
            existing.Seats = vehicle.Seats;
            existing.Description = vehicle.Description;
            existing.IsAvailable = vehicle.IsAvailable;
            existing.LicensePlate = vehicle.LicensePlate;
            existing.Color = vehicle.Color;
        }
    }

    public bool DeleteVehicle(int id)
    {
        var existing = _vehicles.FirstOrDefault(v => v.Id == id);
        if (existing != null)
        {
            _vehicles.Remove(existing);
            return true;
        }
        return false;
    }

    public void ToggleAvailability(int id)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle != null)
        {
            vehicle.IsAvailable = !vehicle.IsAvailable;
        }
    }

    public List<Booking> GetAllBookings()
    {
        foreach (var b in _bookings)
        {
            if (b.Vehicle == null)
            {
                b.Vehicle = _vehicles.FirstOrDefault(v => v.Id == b.VehicleId);
            }
        }
        return _bookings.OrderByDescending(b => b.CreatedAt).ToList();
    }

    public List<Booking> GetBookingsByCustomer(string email)
    {
        return GetAllBookings()
            .Where(b => b.CustomerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public Booking? GetBookingById(int id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null && booking.Vehicle == null)
        {
            booking.Vehicle = _vehicles.FirstOrDefault(v => v.Id == booking.VehicleId);
        }
        return booking;
    }

    public Booking? GetBookingByReference(string reference)
    {
        var booking = _bookings.FirstOrDefault(b => b.BookingReference.Equals(reference, StringComparison.OrdinalIgnoreCase));
        if (booking != null && booking.Vehicle == null)
        {
            booking.Vehicle = _vehicles.FirstOrDefault(v => v.Id == booking.VehicleId);
        }
        return booking;
    }

    public Booking CreateBooking(BookingCreateViewModel model)
    {
        var vehicle = GetVehicleById(model.VehicleId) ?? throw new ArgumentException("Vehicle not found");

        var random = new Random();
        var booking = new Booking
        {
            Id = _bookings.Any() ? _bookings.Max(b => b.Id) + 1 : 1,
            BookingReference = $"VR-{random.Next(100000, 999999)}",
            VehicleId = vehicle.Id,
            Vehicle = vehicle,
            CustomerName = model.CustomerName,
            CustomerEmail = model.CustomerEmail,
            CustomerPhone = model.CustomerPhone,
            PickupLocation = model.PickupLocation,
            DropoffLocation = model.DropoffLocation,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            DailyRate = vehicle.DailyRate,
            InsuranceFee = model.InsuranceOption == "Comprehensive" ? 2500m : 1200m,
            ServiceFee = 1500m,
            Status = BookingStatus.Confirmed,
            PaymentMethod = $"Credit Card ({model.CardNumber.Substring(Math.Max(0, model.CardNumber.Length - 4))})",
            CreatedAt = DateTime.Now,
            SpecialRequests = model.SpecialRequests
        };

        _bookings.Insert(0, booking);

        // Update user stats if exists
        var user = _users.FirstOrDefault(u => u.Email.Equals(model.CustomerEmail, StringComparison.OrdinalIgnoreCase));
        if (user != null)
        {
            user.TotalRentals++;
        }

        return booking;
    }

    public bool CancelBooking(int id)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null)
        {
            booking.Status = BookingStatus.Cancelled;
            return true;
        }
        return false;
    }

    public bool UpdateBookingStatus(int id, BookingStatus status)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null)
        {
            booking.Status = status;
            return true;
        }
        return false;
    }

    public List<User> GetAllUsers()
    {
        return _users.ToList();
    }

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public User? Authenticate(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        if (user != null)
        {
            _currentEmail = user.Email;
        }
        return user;
    }

    public User Register(RegisterViewModel model)
    {
        var user = new User
        {
            Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1,
            FullName = model.FullName,
            Email = model.Email,
            Password = model.Password,
            Phone = model.Phone,
            Role = UserRole.Customer,
            AvatarUrl = "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=200&auto=format&fit=crop&q=80",
            MemberSince = DateTime.Now,
            TotalRentals = 0,
            DriverLicenseNumber = model.DriverLicenseNumber
        };
        _users.Add(user);
        _currentEmail = user.Email;
        return user;
    }

    public User? GetCurrentUser()
    {
        return _users.FirstOrDefault(u => u.Email.Equals(_currentEmail, StringComparison.OrdinalIgnoreCase)) ?? _users.First();
    }

    public void SetCurrentUser(string email)
    {
        var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        if (user != null)
        {
            _currentEmail = user.Email;
        }
    }

    public AdminDashboardViewModel GetAdminDashboardData()
    {
        var allBookings = GetAllBookings();
        return new AdminDashboardViewModel
        {
            TotalVehicles = _vehicles.Count,
            AvailableVehicles = _vehicles.Count(v => v.IsAvailable),
            TotalBookings = allBookings.Count,
            ActiveBookings = allBookings.Count(b => b.Status == BookingStatus.Active || b.Status == BookingStatus.Confirmed),
            TotalRevenue = allBookings.Where(b => b.Status != BookingStatus.Cancelled).Sum(b => b.TotalAmount),
            TotalCustomers = _users.Count(u => u.Role == UserRole.Customer),
            RecentBookings = allBookings.Take(6).ToList(),
            TopVehicles = _vehicles.OrderByDescending(v => v.Rating).Take(4).ToList()
        };
    }
}
