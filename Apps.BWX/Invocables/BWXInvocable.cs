using Apps.BWX.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.BWX.Invocables;

public class BWXInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected BWXClient Client { get; }

    public BWXInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}