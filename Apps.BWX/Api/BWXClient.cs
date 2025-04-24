using Apps.BWX.Constants;
using Apps.BWX.Dtos;
using Apps.BWX.Models.Project.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.BWX.Api;

public class BWXClient : RestClient
{
    protected string AuthToken { get; set; }

    public BWXClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new RestClientOptions()
    {
        BaseUrl = new(Urls.Api)
    })
    {
        var token = creds.First(x => x.KeyName == CredNames.AccessKey).Value;
        var secret = creds.First(x => x.KeyName == CredNames.Secret).Value;

        var restClient = new RestClient(Urls.Api);
        var restRequest = new RestRequest(Urls.TokenUrl, Method.Post)
            .AddBody(new
            {
                accessKey = token,
                secret
            });

        var result = restClient.Execute(restRequest);
        if (result.IsSuccessful == false)
        {
            throw new PluginApplicationException($"Error while getting token: {result.Content}");
        }

        AuthToken = result.Headers?.FirstOrDefault(x => x.Name == "X-AUTH-TOKEN")?.Value?.ToString() ?? string.Empty;
    }

    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        CheckResponseForErrors(response.Content!);
        return response;
    }

    public async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        request.AddHeader("X-AUTH-TOKEN", AuthToken);
        var response = await ExecuteWithErrorHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content!, JsonConfig.Settings)!;
    }

    private void CheckResponseForErrors(string content)
    {
        ErrorResponseDto? errorDto = null;
        try
        {
            errorDto = JsonConvert.DeserializeObject<ErrorResponseDto>(content);
        }
        catch (Exception)
        { }

        if (errorDto != null && errorDto.Status == 0 && !string.IsNullOrEmpty(errorDto.Exception))
        {
            throw new PluginMisconfigurationException(errorDto.Message);
        }

        if (!CheckIfJsonObject(content))
        {
            return;
        }

        var genericResponse = JsonConvert.DeserializeObject<GenericResponse>(content);
        if (!string.IsNullOrEmpty(genericResponse?.Code))
        {
            throw new PluginApplicationException(genericResponse.Message);
        }
    }

    public async Task<IEnumerable<T>> PaginateOnce<T>(RestRequest request)
    {
        request.AddQueryParameter("sort", "sortingByCreateDate");
        request.AddQueryParameter("size", 20);
        request.AddQueryParameter("page", 0);
        var response = await ExecuteWithErrorHandling<PaginationResponse<T>>(request);
        return response.Content;
    }

    public async Task<List<T>> Paginate<T>(RestRequest request)
    {
        var result = new List<T>();
        request.AddQueryParameter("sort", "sortingByCreateDate");
        request.AddQueryParameter("size", 50);
        int page = 0;
        bool last;

        do
        {
            request.AddQueryParameter("page", page);
            var response = await ExecuteWithErrorHandling<PaginationResponse<T>>(request);
            result.AddRange(response.Content);
            last = response.Last;
            ++page;

        } while (!last);

        return result;
    }

    private bool CheckIfJsonObject(string content)
    {
        try
        {
            JObject.Parse(content);
            return true;
        }
        catch (Exception _) { }
        return false;
    }
}