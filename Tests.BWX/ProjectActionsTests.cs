using Apps.BWX.Actions;
using Apps.BWX.Models.Project.Requests;
using Newtonsoft.Json;
using Tests.BWX.Base;
using Blackbird.Applications.Sdk.Common.Files;

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
        
        Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    }

    [TestMethod]
    public async Task UploadFileToProject_WithValidParameters_ShouldUploadFileSuccessfully()
    {
        // Arrange
        var projectActions = new ProjectActions(InvocationContext, FileManager);
        
        var getProjectRequest = new GetProjectRequest
        {
            ProjectId = "8958a12d-f5f1-4cf6-ae98-77dfdd07cbc4"
        };
        
        var uploadFileRequest = new UploadFileRequest
        {
            File = new FileReference 
            { 
                Name = "3 random sentences.txt",
                ContentType = "text/plain"
            },
            Workflows = new List<string> { "TRANSLATION" },
            TargetLocales = new List<string> { "de" }
        };

        // Act
        var result = await projectActions.UploadFileToProject(getProjectRequest, uploadFileRequest);

        // Assert
        Assert.IsNotNull(result);
        Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    }
}
