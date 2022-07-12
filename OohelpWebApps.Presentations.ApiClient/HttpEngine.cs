using OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OohelpWebApps.Presentations.ApiClient;
public class HttpEngine<TRequest, TResponse>
    where TRequest : IRequest, new()
    where TResponse : IResponse, new()
{
    private readonly HttpClient httpClient;
    private static readonly JsonSerializerOptions jOptions = new JsonSerializerOptions
    {
        Converters = { new JsonStringEnumConverter(), new JsonDateOnlyConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public HttpEngine(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    protected HttpEngine()
            : this(HttpClientFactory.CreateDefaultHttpClient())
    {

    }
    public async Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage httpMessage;

        try
        {
            httpMessage = await ProcessRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return new TResponse { Status = Entities.Common.Enums.Status.HttpError, ErrorMessage = ex.GetBaseException().Message };
        }


        var response = await ProcessResponseAsync(httpMessage).ConfigureAwait(false);

        return response;

    }
    internal async Task<HttpResponseMessage> ProcessRequestAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var uri = request.GetUri();

        if (request is IRequestGet)
        {
            return await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);
        }

        HttpMethod method = request switch
        {
            IRequestPost or
            IRequestCreate => HttpMethod.Post,            
            IRequestUpdate => HttpMethod.Put,
            IRequestDelete => HttpMethod.Delete,
            _ => throw new NotImplementedException()
        };

        using StringContent content = new StringContent(JsonSerializer.Serialize(request, jOptions), System.Text.Encoding.UTF8, "application/json");
        using HttpRequestMessage requestMessage = new HttpRequestMessage(method, uri) { Content = content };

        return await this.httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
    }
    internal async Task<TResponse> ProcessResponseAsync(HttpResponseMessage httpResponse)
    {
        using (httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                try
                {
                    using var stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return await JsonSerializer.DeserializeAsync<TResponse>(stream, jOptions).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    return new TResponse
                    {
                        Status = Entities.Common.Enums.Status.ReadResponseError,
                        ErrorMessage = ex.Message,
                    };
                }
            }
            else
            {
                return new TResponse
                {
                    Status = Entities.Common.Enums.Status.HttpError,
                    ErrorMessage = httpResponse.ReasonPhrase
                };
            }
        }
    }
}
