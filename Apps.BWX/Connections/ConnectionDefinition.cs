using Apps.BWX.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.BWX.Connections;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups =>
    [
        new() 
        {
            Name = "ApiToken",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionProperties = new List<ConnectionProperty>()
            {
                new(CredNames.AccessKey)
                {
                    DisplayName = "Access key",
                },
                new(CredNames.Secret)
                {
                    DisplayName = "Secret",
                    Sensitive = true,
                }
            }
        }
    ];

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        yield return new AuthenticationCredentialsProvider(CredNames.AccessKey, values["accessKey"]);
        yield return new AuthenticationCredentialsProvider(CredNames.Secret, values["secret"]);
    }
}