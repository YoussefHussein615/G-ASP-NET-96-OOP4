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

using System;

class Program
{
    static void Main(string[] args)
    {

    }
}
