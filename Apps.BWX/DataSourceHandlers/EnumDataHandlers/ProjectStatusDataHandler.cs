using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class ProjectStatusDataHandler : IStaticDataSourceItemHandler
{
    IEnumerable<DataSourceItem> IStaticDataSourceItemHandler.GetData() => new List<DataSourceItem>
    {
        new("Draft", "Draft"),
        new("Pending", "Pending"),
        new("Approved", "Approved"),
        new("Delivered", "Delivered"),
        new("Invoiced", "Invoiced")
    };
}