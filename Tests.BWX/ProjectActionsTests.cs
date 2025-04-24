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
        Assert.IsTrue(result.TranslatedFiles.Count > 0, "Expected at least one translated file to be returned");
        
        // Log results
        Console.WriteLine($"Downloaded translated files: {JsonConvert.SerializeObject(result, Formatting.Indented)}");
        Console.WriteLine($"Number of files downloaded: {result.TranslatedFiles.Count}");
        
        foreach (var file in result.TranslatedFiles)
        {
            Console.WriteLine($"File: {file.Name}, ContentType: {file.ContentType}");
            Assert.IsFalse(string.IsNullOrEmpty(file.Name), "File name should not be empty");
            Assert.IsFalse(string.IsNullOrEmpty(file.ContentType), "Content type should not be empty");
        }
    }
}
