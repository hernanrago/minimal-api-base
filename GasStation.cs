using MinimalApiBase;

namespace minimal_api_base; // This will be replaced by RootNamespaceName

public class GasStation : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double PricePerGallon { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public override string ToString()
    {
        return $"{Name} - {Address} - ${PricePerGallon}/gallon";
    }
}