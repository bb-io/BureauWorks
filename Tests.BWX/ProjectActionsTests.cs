using Apps.BWX.Actions;
using Apps.BWX.Models.Project.Requests;
using Newtonsoft.Json;
using Tests.BWX.Base;

namespace Tests.BWX;

[TestClass]
public class ProjectActionsTests : TestBase
{
    [TestMethod]
    public async Task DownloadTranslatedFiles_WithValidProjectId_ShouldReturnTranslatedFiles()
    {
        // Arrange
        var projectActions = new ProjectActions(InvocationContext, FileManager);
        var projectId = "8958a12d-f5f1-4cf6-ae98-77dfdd07cbc4";
        
        var getProjectRequest = new GetProjectRequest
        {
            ProjectId = projectId
        };
        
        var downloadRequest = new DownloadTranslatedFilesRequest();

        // Act
        var result = await projectActions.DownloadTranslatedFiles(getProjectRequest, downloadRequest);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.TranslatedFiles);
        
        System.Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    }
}
