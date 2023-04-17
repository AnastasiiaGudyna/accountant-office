using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

namespace IdentityServer.Data.OperationalStores;

public class DeviceFlowStore: IDeviceFlowStore
{
    public Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
    {
        throw new NotImplementedException();
    }

    public Task<DeviceCode> FindByUserCodeAsync(string userCode)
    {
        throw new NotImplementedException();
    }

    public Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
    {
        throw new NotImplementedException();
    }

    public Task UpdateByUserCodeAsync(string userCode, DeviceCode data)
    {
        throw new NotImplementedException();
    }

    public Task RemoveByDeviceCodeAsync(string deviceCode)
    {
        throw new NotImplementedException();
    }
}