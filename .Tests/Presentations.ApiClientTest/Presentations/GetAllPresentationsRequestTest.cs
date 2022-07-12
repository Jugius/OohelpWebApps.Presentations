using OohelpWebApps.Presentations.ApiClient;
using OohelpWebApps.Presentations.ApiClient.Entities.Presentations.Requests;
using Presentations.ApiClientTest.Extentions;
using OohelpWebApps.Presentations.ApiClient.Entities.Presentations.Responses;

namespace Presentations.ApiClientTest.Presentations;
public class GetAllPresentationsRequestTest : TestClassBase
{
    public GetAllPresentationsRequestTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async void Test1()
    {
        var client = HttpClientFactory.CreateDefaultHttpClient();
        client.BaseAddress = new Uri("https://localhost:7024/");

        HttpEngine<GetAllPresentationsRequest, PresentationsResponse> engine = new HttpEngine<GetAllPresentationsRequest, PresentationsResponse>(client);
        
        
        

        GetAllPresentationsRequest request = new GetAllPresentationsRequest
        {
            Key = "NTCaXLw8YUmlm3OyxShl7Q",
            ShowAllAvailable = true,
        };

        var result = await engine.QueryAsync(request);

        output.WriteJson(result);
    }   

}
