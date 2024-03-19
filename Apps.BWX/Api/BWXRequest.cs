using Apps.BWX.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.BWX.Api;

public class BWXRequest : RestRequest
{
    public BWXRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(
        endpoint, method)
    {
        var token = creds.First(x => x.KeyName == "accessKey").Value;
        var secret = creds.First(x => x.KeyName == "secret").Value;
        this.AddHeader("X-AUTH-TOKEN", GetXAuthToken(token, secret));
    }

    private string GetXAuthToken(string accessKey, string secret)
    {
        var restClient = new RestClient(Urls.Api);
        var restRequest = new RestRequest(Urls.TokenUrl, Method.Post);
        restRequest.AddBody(new
        {
            accessKey = accessKey,
            secret = secret
        });
        var result = restClient.Execute(restRequest);
        return result.Headers.FirstOrDefault(x => x.Name == "X-AUTH-TOKEN").Value.ToString();
    }
}