using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly ParkingLotService _service;

    public VehicleController(ParkingLotService service)
    {
        _service = service;
    }

    [HttpPost("add/firstclass")]
    public IActionResult AddFirstClassVehicle(FirstClassVehicle vehicle)
    {
        _service.AddVehicle(vehicle);
        return Ok($"{vehicle.LicensePlate} birinci sınıf aracı eklendi.");
    }

    [HttpPost("add/secondclass")]
    public IActionResult AddSecondClassVehicle(SecondClassVehicle vehicle)
    {
        _service.AddVehicle(vehicle);
        return Ok($"{vehicle.LicensePlate} ikinci sınıf aracı eklendi.");
    }

    [HttpPost("add/thirdclass")]
    public IActionResult AddThirdClassVehicle(ThirdClassVehicle vehicle)
    {
        _service.AddVehicle(vehicle);
        return Ok($"{vehicle.LicensePlate} üçüncü sınıf aracı eklendi.");
    }

    [HttpGet("all")]
    public IActionResult GetAllVehicles()
    {
        return Ok(_service.GetAllVehicles());
    }

    [HttpGet("type/{type}")]
    public IActionResult GetVehiclesByType(int type)  // Change the parameter to int
    {
        switch (type)
        {
            case 1:
                return Ok(_service.GetVehiclesByType<FirstClassVehicle>());
            case 2:
                return Ok(_service.GetVehiclesByType<SecondClassVehicle>());
            case 3:
                return Ok(_service.GetVehiclesByType<ThirdClassVehicle>());
            default:
                return NotFound("Geçersiz araç türü.");
        }
    }


    [HttpPost("remove")]
    public IActionResult RemoveVehicle(Vehicle vehicle)
    {
        _service.RemoveVehicle(vehicle);
        return Ok($"{vehicle.LicensePlate} kaldırıldı.");
    }

    [HttpGet("fee/{licensePlate}")]
    public IActionResult CalculateFee(string licensePlate)
    {
        var vehicle = _service.GetAllVehicles().FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle == null) return NotFound($"{licensePlate} plakalı araç bulunamadı.");
        return Ok(_service.CalculateFee(vehicle));
    }
    
    [HttpGet("horsepower/{licensePlate}")]
    public IActionResult CalculateHorsePower(string licensePlate)
    {
        var vehicle = _service.GetAllVehicles().FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle == null) return NotFound($"{licensePlate} plakalı araç bulunamadı.");
        return Ok($"HorsePower for {licensePlate}: {vehicle.HorsePower}");
    }

    [HttpGet("service/carwash/{licensePlate}")]
    public IActionResult AccessCarWashService(string licensePlate)
    {
        var vehicle = _service.GetAllVehicles().OfType<FirstClassVehicle>().FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle == null) return NotFound($"{licensePlate} plakalı araç bulunamadı.");
        return Ok(vehicle.CarWash());
    }

    [HttpGet("service/tirechange/{licensePlate}")]
    public IActionResult AccessTireChangeService(string licensePlate)
    {
        var vehicle = _service.GetAllVehicles().OfType<SecondClassVehicle>().FirstOrDefault(v => v.LicensePlate == licensePlate);
        if (vehicle == null) return NotFound($"{licensePlate} plakalı araç bulunamadı.");
        return Ok(vehicle.ChangeTire());
    }
}