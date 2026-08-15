// Every shipment type implements this so tracking status can be
// requested through a common contract, regardless of the concrete type.
public interface ITrackable
{
    string GetTrackingStatus();
}
