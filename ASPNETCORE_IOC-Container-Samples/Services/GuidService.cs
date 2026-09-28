namespace ASPNETCORE_IOC_Container_Samples.Services;
public class GuidService : IGuidService
{
    private readonly string _guidString;
    public GuidService()
    {
        _guidString = Guid.NewGuid().ToString();
    }
    public string GetGuidString()
    {
        return _guidString;
    }
}
