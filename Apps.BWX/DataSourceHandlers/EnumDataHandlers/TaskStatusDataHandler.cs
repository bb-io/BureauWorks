using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class TaskStatusDataHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData() => new List<DataSourceItem>
    {
        new("DRAFT", "Draft"),
        new("PENDING", "Pending"),
        new("APPROVED", "Approved"),
        new("DELIVERED", "Delivered"),
        new("INVOICED", "Invoiced")
    };
}