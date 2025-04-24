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
        var projectId = "19b1bc57-b470-4557-99d7-eb64f709b4cd";
        
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
