using System;

public class DeliveryCenter
{
    public string CenterName { get; set; }

    // Aggregation: DeliveryCenter references a Driver, but does not own its
    // lifetime — the Driver was created independently and can outlive this
    // DeliveryCenter or be reassigned elsewhere.
    public Driver Driver { get; set; }

    private Shipment[] shipments = new Shipment[20];

    public Shipment this[int index]
    {
        get
        {
            if (index < 0 || index >= shipments.Length)
            {
                return null;
            }
            return shipments[index];
        }
        set
        {
            if (index < 0 || index >= shipments.Length)
            {
                return;
            }
            shipments[index] = value;
        }
    }

    public Shipment this[string trackingCode]
    {
        get
        {
            foreach (Shipment shipment in shipments)
            {
                if (shipment != null && shipment.TrackingCode == trackingCode)
                {
                    return shipment;
                }
            }
            return null;
        }
    }

    public bool AddShipment(Shipment shipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)
            {
                shipments[i] = shipment;
                return true;
            }
        }
        return false;
    }

    public bool RemoveShipment(string trackingCode)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
            {
                shipments[i] = null;
                return true;
            }
        }
        return false;
    }

    public void PrintAllShipments(string header)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine(header);
        Console.WriteLine("==========================================");
        Console.WriteLine();

        if (Driver != null)
        {
            Console.WriteLine("Driver : " + Driver.FullName);
            Console.WriteLine();
        }

        foreach (Shipment shipment in shipments)
        {
            if (shipment != null)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
                // No manual type-checking here — shipment.PrintShipment()
                // resolves to the correct override at runtime (dynamic binding).
                shipment.PrintShipment();
                Console.WriteLine();
            }
        }
    }

    // Loops through all shipments and prints their tracking status via
    // the ITrackable interface — no concrete-type checking required.
    public void PrintTrackingStatuses()
    {
        foreach (Shipment shipment in shipments)
        {
            if (shipment is ITrackable trackable)
            {
                Console.WriteLine(trackable.GetTrackingStatus());
            }
        }
    }
}
