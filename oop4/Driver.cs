// Aggregation: a Driver can exist completely independently of any
// DeliveryCenter (it is only referenced by one, not owned/created by it).
public class Driver
{
    public int DriverId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }

    public Driver(int driverId, string fullName, string phoneNumber)
    {
        DriverId = driverId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
}
