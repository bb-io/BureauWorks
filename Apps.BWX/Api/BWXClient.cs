using Apps.BWX.Constants;
using Apps.BWX.Models.Responses;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.BWX.Api;

public class BWXClient : RestClient
{
    public BWXClient() : base(new RestClientOptions()
    {
        BaseUrl = new(Urls.Api)
    })
    {
    }

    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        
        if (!CheckIfJsonObject(response.Content!))
            return response;

        var genericResponse = JsonConvert.DeserializeObject<GenericResponse>(response.Content!);

        if (!string.IsNullOrEmpty(genericResponse?.Code))
            throw new Exception($"Error ({genericResponse.Code}): {genericResponse.Message}");

        return response;
    }

    public async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content!, JsonConfig.Settings)!;
    }

    public async Task<List<T>> Paginate<T>(RestRequest request)
    {
        var result = new List<T>();
        request.AddQueryParameter("sort", "sortingByCreateDate");
        int page = 0;
        bool last = false;
        do
        {
            request.AddQueryParameter("size", 20);
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