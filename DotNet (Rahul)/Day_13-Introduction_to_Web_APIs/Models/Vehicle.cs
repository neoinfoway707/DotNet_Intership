namespace Day_13_Introduction_to_Web_APIs.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }

    public class VehicleService
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle { Id = 1, Brand = "Toyota", Model = "Fortuner", Year = 2024, Price = 3343000.00m },
            new Vehicle { Id = 2, Brand = "Hyundai", Model = "Creta", Year = 2025, Price = 1100000.00m },
            new Vehicle { Id = 3, Brand = "Tata", Model = "Nexon EV", Year = 2026, Price = 1450000.00m },
            new Vehicle { Id = 4, Brand = "Mahindra", Model = "XUV700", Year = 2025, Price = 1650000.00m },
            new Vehicle { Id = 5, Brand = "Honda", Model = "City", Year = 2024, Price = 1180000.00m }
        };
        public static List<Vehicle> GetAllVehicles() { return _vehicles; }

        public static Vehicle? GetVehicle(int id)
        {
            var findVehicle = _vehicles.FirstOrDefault(x => x.Id == id);
            if (findVehicle == null)
                return null;
            return findVehicle;
        }

        public static Vehicle? AddVehicle(VehicleDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Brand = vehicleDto.Brand,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Price = vehicleDto.Price
            };

            var last = _vehicles.Count();
            vehicle.Id = _vehicles.Any() ? _vehicles.Max(x => x.Id) + 1 : 1;
            _vehicles.Add(vehicle);
            return vehicle;
        }

        public static Vehicle? UpdateVehicle(int id, VehicleDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Brand = vehicleDto.Brand,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Price = vehicleDto.Price
            };

            var findVehicle = _vehicles.FirstOrDefault(x => x.Id == id);
            if (findVehicle == null) return null;

            findVehicle.Brand = vehicle.Brand;
            findVehicle.Model = vehicle.Model;
            findVehicle.Year = vehicle.Year;
            findVehicle.Price = vehicle.Price;

            return findVehicle;
        }

        public static bool DeleteVehicle(int id)
        {
            var findVehicle = _vehicles.FirstOrDefault(x => x.Id == id);
            if (findVehicle == null) return false;
            _vehicles.Remove(findVehicle);
            return true;
        }
    }
}