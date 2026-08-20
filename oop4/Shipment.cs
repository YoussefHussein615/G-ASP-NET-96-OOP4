using System;

// "abstract" — Shipment can no longer be instantiated directly
// (no "new Shipment(...)" anywhere). It exists only to be inherited from.
public abstract class Shipment
{
    private string trackingCode;
    private string description;
    private decimal weight;
    private decimal deliveryFee;
    private DeliveryAddress destination;

    // Read-only from outside the class
    public string TrackingCode
    {
        get { return trackingCode; }
        private set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                trackingCode = value;
            }
        }
    }

    public string Description
    {
        get { return description; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                description = value;
            }
        }
    }

    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
        }
    }

    public decimal DeliveryFee
    {
        get { return deliveryFee; }
        private set
        {
            if (value > 0)
            {
                deliveryFee = value;
            }
        }
    }

    public DeliveryAddress Destination
    {
        get { return destination; }
        set { destination = value; }
    }

    // abstract — no body here at all; every concrete derived class
    // MUST provide its own implementation.
    public abstract decimal EstimatedCost { get; }

    // Constructor 1: trackingCode only, everything else defaults
    protected Shipment(string trackingCode)
    {
        TrackingCode = trackingCode;
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;
        Destination = new DeliveryAddress("Unknown", "Unknown", 0);
    }

    // Constructor 2: full data
    protected Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
    {
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        Destination = destination;
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
        {
            DeliveryFee = newFee;
        }
    }

    // Overload 1: simply set a new weight
    public void UpdateWeight(decimal newWeight)
    {
        Weight = newWeight;
    }

    // Overload 2: set a new weight, then add the extra packing weight on top
    public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
    {
        Weight = newWeight + extraPackingWeight;
    }

    // Shared helper so derived classes don't repeat these lines
    protected void PrintCommonInfo()
    {
        Console.WriteLine("Tracking Code : " + TrackingCode);
        Console.WriteLine("Description   : " + Description);
        Console.WriteLine("Weight        : " + Weight + " KG");
        Console.WriteLine("Delivery Fee  : " + DeliveryFee + " EGP");
    }

    // abstract — no body here at all; every concrete derived class
    // MUST provide its own implementation.
    public abstract void PrintShipment();
}
