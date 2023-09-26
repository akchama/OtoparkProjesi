public class ParkingLotService
{
    private List<Vehicle> _parkingLot = new List<Vehicle>();
    private ParkingLot _parkingLotDetails = new ParkingLot { Fee = 10 };  // Temel ücret 10 TL 

    public void AddVehicle(Vehicle vehicle)
    {
        _parkingLot.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        _parkingLot.Remove(vehicle);
    }

    public List<Vehicle> GetAllVehicles()
    {
        return _parkingLot;
    }

    public List<Vehicle> GetVehiclesByType<T>() where T : Vehicle
    {
        return _parkingLot.OfType<T>().Cast<Vehicle>().ToList();
    }
    
    public string CalculateFee(Vehicle vehicle)
    {
        double calculatedFee = _parkingLotDetails.Fee;
        if (vehicle is FirstClassVehicle) calculatedFee *= 3;
        else if (vehicle is SecondClassVehicle) calculatedFee *= 2;

        return $"Ücret: {calculatedFee} TL";
    }

}