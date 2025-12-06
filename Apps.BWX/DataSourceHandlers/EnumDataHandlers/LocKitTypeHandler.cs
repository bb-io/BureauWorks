using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers;

public class LocKitTypeHandler : IStaticDataSourceItemHandler
{
    IEnumerable<DataSourceItem> IStaticDataSourceItemHandler.GetData() => new List<DataSourceItem>
    {
        new("XLIFF", "XLIFF"),
        new("XLSX", "XLSX")
    };
}