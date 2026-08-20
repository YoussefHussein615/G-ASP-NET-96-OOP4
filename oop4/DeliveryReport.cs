using System;

// A static class that only ever talks to shipments through the ITrackable
// and IInsurable interfaces — it doesn't need to know (or care) about the
// concrete Shipment types at all. This is interface polymorphism.
public static class DeliveryReport
{
    public static void PrintShipment(ITrackable shipment)
    {
        Console.WriteLine(shipment.GetTrackingStatus());
    }

    public static void PrintInsurance(IInsurable shipment)
    {
        Console.WriteLine(shipment.CalculateInsurance().ToString("F2") + " EGP");
    }
}
