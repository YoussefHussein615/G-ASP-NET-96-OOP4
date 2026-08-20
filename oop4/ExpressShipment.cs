using System;

public class ExpressShipment : Shipment, ITrackable, IInsurable
{
    private decimal extraFee;

    public decimal ExtraFee
    {
        get { return extraFee; }
        set
        {
            if (value >= 0)
            {
                extraFee = value;
            }
        }
    }

    // Constructor chaining via ": base(...)"
    public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        ExtraFee = extraFee;
    }

    // Implements the abstract EstimatedCost from Shipment
    public override decimal EstimatedCost
    {
        get { return DeliveryFee + (Weight * 5) + ExtraFee; }
    }

    // Implements the abstract PrintShipment() from Shipment
    public override void PrintShipment()
    {
        Console.WriteLine("Express Shipment");
        Console.WriteLine();
        PrintCommonInfo();
        Console.WriteLine("Extra Fee     : " + ExtraFee + " EGP");
        Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
    }

    // ITrackable
    public string GetTrackingStatus()
    {
        return "Shipment " + TrackingCode + " is Out for Delivery.";
    }

    // IInsurable — 8% of EstimatedCost
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.08m;
    }
}
