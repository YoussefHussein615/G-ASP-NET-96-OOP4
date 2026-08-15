/*

 PART 01 : THEORETICAL QUESTIONS

Q1 — Abstraction

a) Abstraction in OOP means exposing only the essential, relevant
   details of an object to the outside world, while hiding the
   internal complexity of HOW those details are implemented. In C#
   this is expressed through abstract classes and interfaces: outside
   code depends on WHAT a Shipment can do without needing to know HOW each concrete type
   actually calculates or prints that information.
   

b) Abstraction is one of the four pillars of OOP because it's what
   makes large systems manageable: it lets you design against a
   simple, stable contract instead of against every concrete
   implementation detail. New shipment types can be added later without
   touching any code that already works against the abstraction — which
   is exactly the scenario described at the top of this assignment

Q2 — Abstract Classes vs. Interfaces

a) An ABSTRACT CLASS can contain both abstract members (no
   implementation, must be overridden) AND fully implemented members
   that derived classes  inherit directly ,alongside the 
   abstract EstimatedCost and PrintShipment(). A class can inherit from
   only ONE abstract class (single inheritance).
   An INTERFACE, by contrast, only defines a contract — a list of
   members with no implementation at all, A class can implement MANY interfaces at once.

b) Choose an interface instead of an abstract class when you need to
   describe a capability that unrelated classes can share, without
   forcing them into a single inheritance hierarchy — for example,
   ITrackable and IInsurable here could just as easily be implemented
   by something that isn't a Shipment at all, Prefer an abstract class instead when the
   types genuinely share both an "is-a" relationship AND common state
   or behavior worth inheriting (like all Shipments sharing
   TrackingCode, Weight, DeliveryFee, and the same validation rules).

c) A class can inherit from only ONE abstract class (or any base
   class) — C# does not support multiple class inheritance, to avoid
   ambiguity when two base classes define conflicting members. However,
   a class CAN implement multiple interfaces at the same time, because interfaces carry no state and no
   implementation, so there's no ambiguity to resolve.

*/

//  PART 02 : PRACTICAL
using System;

class Program
{
    static void Main(string[] args)
    {
        
        Driver driver = new Driver(1, "Ahmed Mohamed", "01000000000");
        DeliveryCenter center = new DeliveryCenter();
        center.CenterName = "Delivery Center";
        center.Driver = driver;

        // a. Create one StandardShipment
        DeliveryAddress addr1 = new DeliveryAddress("Cairo", "Tahrir Street", 15);
        StandardShipment standardShipment = new StandardShipment("SH001", "Laptop", 3, 80, addr1);

        // b. Create one ExpressShipment
        DeliveryAddress addr2 = new DeliveryAddress("Cairo", "Nasr Street", 22);
        ExpressShipment expressShipment = new ExpressShipment("SH002", "Mobile Phone", 2, 60, addr2, 30);

        // c. Create one InternationalShipment
        DeliveryAddress addr3 = new DeliveryAddress("Berlin", "Alexanderplatz", 5);
        InternationalShipment internationalShipment = new InternationalShipment("SH003", "Television", 8, 120, addr3, "Germany", 100);

        // d. Add all shipments to the DeliveryCenter
        center.AddShipment(standardShipment);
        center.AddShipment(expressShipment);
        center.AddShipment(internationalShipment);

        // e. Print all shipment details
        center.PrintAllShipments(center.CenterName);

        // f. Print the tracking status of every shipment
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Tracking Status");
        Console.WriteLine();
        center.PrintTrackingStatuses();
        Console.WriteLine();

        // g. Print the insurance cost of every shipment
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Insurance");
        Console.WriteLine();
        Console.Write("Standard Shipment Insurance : ");
        DeliveryReport.PrintInsurance(standardShipment);
        Console.Write("Express Shipment Insurance : ");
        DeliveryReport.PrintInsurance(expressShipment);
        Console.Write("International Shipment Insurance : ");
        DeliveryReport.PrintInsurance(internationalShipment);
        Console.WriteLine();

        // h. Store the shipment objects in an ITrackable[] array and print their tracking statuses
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Printing Using ITrackable[]...");
        Console.WriteLine();
        ITrackable[] trackables = { standardShipment, expressShipment, internationalShipment };
        foreach (ITrackable t in trackables)
        {
            // Declared type here is ITrackable, fixed at compile time,
            // but GetTrackingStatus() still resolves per real object at runtime.
            Console.WriteLine(t.GetTrackingStatus());
        }
        Console.WriteLine();

        // i. Store the shipment objects in an IInsurable[] array and print their insurance values
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Printing Using IInsurable[]...");
        Console.WriteLine();
        IInsurable[] insurables = { standardShipment, expressShipment, internationalShipment };
        foreach (IInsurable i in insurables)
        {
            Console.WriteLine(i.CalculateInsurance().ToString("F2") + " EGP");
        }
        Console.WriteLine();
        Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
        Console.WriteLine();

       
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Printing Using DeliveryHelper...");
        Console.WriteLine();
        DeliveryHelper.PrintShipmentDetails(standardShipment);
        DeliveryHelper.PrintShipmentDetails(expressShipment);
        DeliveryHelper.PrintShipmentDetails(internationalShipment);
        Console.WriteLine("==========================================");
        Console.WriteLine();


        Console.WriteLine("Updating Weight...");
        Console.WriteLine();
        Console.WriteLine("Original Weight : " + standardShipment.Weight + " KG");
        standardShipment.UpdateWeight(5);
        Console.WriteLine("Updated Weight : " + standardShipment.Weight + " KG");
        standardShipment.UpdateWeight(5, 0.5m);
        Console.WriteLine("Updated Weight After Packing : " + standardShipment.Weight + " KG");
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine();

        Console.WriteLine("Printing Using Shipment[]...");
        Console.WriteLine();
        Shipment[] mixedShipments = { standardShipment, expressShipment, internationalShipment };
        foreach (Shipment s in mixedShipments)
        {
            s.PrintShipment();
            Console.WriteLine();
        }
        Console.WriteLine("==========================================");
        Console.WriteLine();

        Console.WriteLine("Demonstrating sealed class and sealed method...");
        Console.WriteLine();


        DeliveryAddress addr4 = new DeliveryAddress("Suez", "Main Street", 1);
        CompletedShipment completedShipment = new CompletedShipment("SH004", "Books", 1.5m, 40, addr4);
        completedShipment.PrintShipment();
        // The line below would NOT compile if uncommented, because
        // CompletedShipment is sealed:
        // public class SubShipment : CompletedShipment { }

        Console.WriteLine();

        // Sealed METHOD: PriorityInternationalShipment.GenerateCustomsReport()
        // is a sealed override — it runs normally, but no further class can
        // override it again.
        PriorityInternationalShipment priorityShipment = new PriorityInternationalShipment("SH005", "Machinery", 20, 300, addr3, "France", 150);
        priorityShipment.GenerateCustomsReport();
        // The line below would NOT compile if uncommented, because
        // GenerateCustomsReport() is sealed in PriorityInternationalShipment:
        // public class EvenMorePriority : PriorityInternationalShipment
        // {
        //     public override void GenerateCustomsReport() { }
        // }

        // The line below would NOT compile if uncommented, because Shipment
        // is now abstract and cannot be instantiated directly:
        // Shipment s2 = new Shipment("SH999");
    }
}
