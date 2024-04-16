using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class ProjectStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
     => new()
    {
        {"Draft", "Draft"},
        {"Pending", "Pending"},
        {"Approved", "Approved"},
        {"Delivered", "Delivered"},
        {"Invoiced", "Invoiced"},
    };
}