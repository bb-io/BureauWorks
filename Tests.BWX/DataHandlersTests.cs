using Tests.BWX.Base;
using Apps.BWX.DataSourceHandlers;
using Apps.BWX.Models.Project.Requests;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Tests.BWX;

[TestClass]
public class DataHandlersTests : TestBase
{
    [TestMethod]
    public async Task WorkUnitDataHandler_ReturnsWorkflowUnits()
    {
        // Arrange
        var project = new GetProjectRequest { ProjectId = "ff84a3ed-1b52-4f2d-9269-9185e2f6aec7" };
        var handler = new WorkUnitDataHandler(InvocationContext, project);

        // Act
        var result = await handler.GetDataAsync(new DataSourceContext { SearchString = "" }, CancellationToken.None);

        // Assert
        foreach (var item in result)
            Console.WriteLine($"{item.Value} - {item.DisplayName}");
        Assert.IsNotNull(result);
    }
}
