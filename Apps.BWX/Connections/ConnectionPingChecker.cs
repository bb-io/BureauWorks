using Apps.BWX.Api;
using Apps.BWX.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.BWX.Connections;

public class ConnectionPingChecker : IConnectionValidator
{
    public ValueTask<ConnectionValidationResponse> ValidateConnection(IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new BWXClient();
        var request = new BWXRequest("/api/v3/project", Method.Get, authProviders);        
        try
        {
            var result = client.Paginate<ProjectDto>(request).Result;
            return new ValueTask<ConnectionValidationResponse>(new ConnectionValidationResponse()
            {
                IsValid = true,
                Message = "Success"
            });
        }
        catch (Exception ex)
        {
            return new ValueTask<ConnectionValidationResponse>(new ConnectionValidationResponse()
            {
                IsValid = false,
                Message = ex.Message
            });
        }
    }
}