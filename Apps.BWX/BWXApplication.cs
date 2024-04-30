using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.BWX;

public class BWXApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.CatAndTms, ApplicationCategory.TranslationBusinessManagement];
        set { }
    }
    
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