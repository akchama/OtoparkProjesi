public class Vehicle
{
    public string Color { get; set; }
    public string LicensePlate { get; set; }
    public int ModelYear { get; set; }
    public string ModelName { get; set; }
    public double HorsePower { get; set; }
}

public class FirstClassVehicle : Vehicle
{
    public bool HasAutopilot { get; set; }
    public double Price { get; set; }
    
    public string CarWash()
    {
        return "Birinci sinif yikama.";
    }
}

public class SecondClassVehicle : Vehicle
{
    public double TrunkVolume { get; set; }
    public bool HasSpareTire { get; set; }

    public string ChangeTire()  // New method for tire change service
    {
        return "Lastik degisimi.";
    }
}

public class ThirdClassVehicle : Vehicle
{
    public double TrunkVolume { get; set; }
    public bool HasSpareTire { get; set; }
}