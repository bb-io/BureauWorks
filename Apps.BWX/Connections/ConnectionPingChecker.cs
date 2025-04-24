using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.BWX.Connections;

public class ConnectionPingChecker : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        try
        {
            var client = new BWXClient(authProviders);
            var request = new RestRequest("/api/v3/language", Method.Get); 
            var result = await client.ExecuteWithErrorHandling(request);
            return new ConnectionValidationResponse()
            {
                IsValid = true,
                Message = "Success"
            };
        }
        catch (Exception ex)
        {
            return new ConnectionValidationResponse()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}