using System;
using System.Text;

// A static class: it can't be instantiated, it only holds a utility method.
public static class DeliveryHelper
{
    public static void PrintShipmentDetails(Shipment shipment)
    {
        // shipment.PrintShipment() resolves to whichever override matches
        // the object's real (runtime) type — this is dynamic binding.
        shipment.PrintShipment();
        Console.WriteLine(FormatTypeName(shipment.GetType().Name) + " Printed Successfully.");
        Console.WriteLine();
    }

    // Turns "StandardShipment" into "Standard Shipment" for display.
    private static string FormatTypeName(string typeName)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < typeName.Length; i++)
        {
            if (i > 0 && char.IsUpper(typeName[i]))
            {
                result.Append(' ');
            }
            result.Append(typeName[i]);
        }
        return result.ToString();
    }
}
