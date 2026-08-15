using System;

public class StandardShipment : Shipment, ITrackable, IInsurable
{
    // Constructor chaining via ": base(...)" — no extra properties of its own
    public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
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
        Console.WriteLine("Standard Shipment");
        Console.WriteLine();
        PrintCommonInfo();
        Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
    }

    // ITrackable
    public string GetTrackingStatus()
    {
        return "Shipment " + TrackingCode + " is Ready.";
    }

    // IInsurable — 5% of EstimatedCost
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m;
    }
}
