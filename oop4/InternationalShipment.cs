using System;

public class InternationalShipment : Shipment, ITrackable, IInsurable
{
    private string destinationCountry;
    private decimal customsFee;

    public string DestinationCountry
    {
        get { return destinationCountry; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                destinationCountry = value;
            }
        }
    }

    public decimal CustomsFee
    {
        get { return customsFee; }
        set
        {
            if (value >= 0)
            {
                customsFee = value;
            }
        }
    }

    // Constructor chaining via ": base(...)"
    public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }

    // Implements the abstract EstimatedCost from Shipment
    public override decimal EstimatedCost
    {
        get { return DeliveryFee + (Weight * 5) + CustomsFee; }
    }

    // Implements the abstract PrintShipment() from Shipment
    public override void PrintShipment()
    {
        Console.WriteLine("International Shipment");
        Console.WriteLine();
        PrintCommonInfo();
        Console.WriteLine("Destination Country : " + DestinationCountry);
        Console.WriteLine("Customs Fee         : " + CustomsFee + " EGP");
        Console.WriteLine("Estimated Cost      : " + EstimatedCost + " EGP");
    }

    // ITrackable — virtual so PriorityInternationalShipment could customize it if needed
    public virtual string GetTrackingStatus()
    {
        return "Shipment " + TrackingCode + " has been Delivered.";
    }

    // IInsurable — 12% of EstimatedCost
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.12m;
    }

    // virtual so PriorityInternationalShipment can override it (and seal that override)
    public virtual void GenerateCustomsReport()
    {
        Console.WriteLine("Standard customs report generated for " + TrackingCode + ".");
    }
}
