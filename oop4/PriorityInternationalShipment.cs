using System;

public class PriorityInternationalShipment : InternationalShipment
{
    public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
        : base(trackingCode, description, weight, deliveryFee, destination, destinationCountry, customsFee)
    {
    }

    // "sealed override" — this override is final: no class that inherits
    // from PriorityInternationalShipment is allowed to override it again.
    public sealed override void GenerateCustomsReport()
    {
        Console.WriteLine("PRIORITY customs report generated for " + TrackingCode + " (expedited clearance).");
    }
}
