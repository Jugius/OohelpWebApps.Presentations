using OohelpWebApps.Presentations.Models;

namespace OohelpWebApps.Presentations.Services;

public class ClientService
{
    public async Task<ClientInfoViewModel> GetClientInfo(Guid Id)
    {
        return await Task.FromResult(new Models.ClientInfoViewModel { Name = "Ad Strategy", Logo = "Logo_w150.png" });
    }
}
