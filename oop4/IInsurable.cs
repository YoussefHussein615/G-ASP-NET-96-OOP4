// Every shipment type implements this so insurance cost can be
// requested through a common contract, regardless of the concrete type.
public interface IInsurable
{
    decimal CalculateInsurance();
}
