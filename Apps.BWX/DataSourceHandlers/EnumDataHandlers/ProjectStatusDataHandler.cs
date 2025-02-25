using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class ProjectStatusDataHandler : IStaticDataSourceItemHandler
{
    IEnumerable<DataSourceItem> IStaticDataSourceItemHandler.GetData() => new List<DataSourceItem>()
    {
        new DataSourceItem("Draft", "Draft"),
        new DataSourceItem("Pending", "Pending"),
        new DataSourceItem("Approved", "Approved"),
        new DataSourceItem("Delivered", "Delivered"),
        new DataSourceItem("Invoiced", "Invoiced")
    };
}