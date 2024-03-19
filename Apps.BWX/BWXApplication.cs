using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.BWX;

public class BWXApplication : IApplication
{
    public string Name
    {
        get => "BWX";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}