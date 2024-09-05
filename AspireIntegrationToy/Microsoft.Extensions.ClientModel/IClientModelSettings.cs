namespace Microsoft.Extensions.ClientModel;

public interface IClientModelSettings
{
    Uri? Endpoint { get; set; }
}