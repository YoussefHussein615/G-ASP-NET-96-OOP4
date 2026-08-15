using System;

// "sealed class" — no other class is allowed to inherit from CompletedShipment.
// It still inherits everything from Shipment; it just can't be a base class itself.
public sealed class CompletedShipment : Shipment, ITrackable, IInsurable
{
    public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
    }

    // Implements the abstract EstimatedCost from Shipment
    public override decimal EstimatedCost
    {
        get { return DeliveryFee + (Weight * 5); }
    }

    // Implements the abstract PrintShipment() from Shipment
    public override void PrintShipment()
    {
        Console.WriteLine("Completed Shipment");
        Console.WriteLine();
        PrintCommonInfo();
        Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
    }

    // ITrackable
    public string GetTrackingStatus()
    {
        return "Shipment " + TrackingCode + " has been Delivered.";
    }

    // IInsurable — treated like a standard shipment for insurance purposes
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m;
    }
}
