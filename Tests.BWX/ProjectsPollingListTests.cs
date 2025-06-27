using Apps.BWX.Dtos;
using Apps.BWX.Models.Project.Requests;
using Apps.BWX.Webhooks;
using Apps.BWX.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Polling;
using Newtonsoft.Json;
using Tests.BWX.Base;

namespace Tests.BWX;

[TestClass]
public class ProjectsPollingListTests : TestBase
{
    private ProjectsPollingList _projectsPollingList;
    private readonly List<string> _expectedProjectIds = ["8958a12d-f5f1-4cf6-ae98-77dfdd07cbc4", "d77691b4-2c67-4fa7-9426-8794a91c7880", "42188c5f-f250-4352-ac45-080ff3441814"]; // Replace with actual project IDs from your system

    [TestInitialize]
    public void Initialize()
    {
        _projectsPollingList = new ProjectsPollingList(InvocationContext);
    }

    [TestMethod]
    public async Task OnProjectsCreated_WithNullMemory_ShouldReturnCorrectIds()
    {
        // Arrange
        var request = new PollingEventRequest<ProjectsMemory>
        {
            Memory = null,
            PollingTime = DateTime.UtcNow
        };

        // Act
        var response = await _projectsPollingList.OnProjectsCreated(request);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Memory);
        Assert.IsNotNull(response.Result);
        
        // Log for debugging
        Console.WriteLine($"Response: {JsonConvert.SerializeObject(response, Formatting.Indented)}");
        Console.WriteLine($"Found projects: {response.Result.Projects.Count}");
        Console.WriteLine($"Stored IDs in memory: {string.Join(", ", response.Memory.ProjectIds)}");
        
        // The first run should not trigger the event since we're just building initial memory
        Assert.IsFalse(response.FlyBird, "FlyBird should be false for first run with null memory");
    }

    [TestMethod]
    public async Task OnProjectsCreated_WithExistingMemory_ShouldIdentifyNewProjects()
    {
        // Arrange
        // Only include some IDs to simulate new projects
        var partialIds = _expectedProjectIds.Take(1).ToList(); 
        var expectedPartialIdsCount = partialIds.Count;
        var memory = new ProjectsMemory
        {
            LastPollingTime = DateTime.UtcNow.AddHours(-24), // Look back 24 hours
            ProjectIds = partialIds
        };
        
        var request = new PollingEventRequest<ProjectsMemory>
        {
            Memory = memory,
            PollingTime = DateTime.UtcNow
        };

        // Act
        var response = await _projectsPollingList.OnProjectsCreated(request);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Memory);
        Assert.IsNotNull(response.Result);
        
        // Log for debugging
        Console.WriteLine($"Response: {JsonConvert.SerializeObject(response, Formatting.Indented)}");
        Console.WriteLine($"Previously known IDs: {string.Join(", ", partialIds)}");
        Console.WriteLine($"Updated memory IDs: {string.Join(", ", response.Memory.ProjectIds)}");
        
        // Verify new projects were found if any exist
        Console.WriteLine($"New projects found: {response.Result.Projects.Count}");
        
        if (response.Result.Projects.Count > 0)
        {
            // We should have more IDs in memory than we started with
            Assert.IsTrue(response.Memory.ProjectIds.Count > expectedPartialIdsCount, 
                "Should find additional IDs when new projects exist");
            Assert.IsTrue(response.FlyBird, 
                "FlyBird should be true when new projects are found");
        }
    }

    [TestMethod]
    public async Task OnProjectsCreated_WithFullMemory_ShouldNotFindNewProjects()
    {
        // This test verifies that when our memory already contains all recent projects,
        // no new projects are found and the event is not triggered

        // Arrange - First get all the current projects
        var initialRequest = new PollingEventRequest<ProjectsMemory>
        {
            Memory = null,
            PollingTime = DateTime.UtcNow
        };
        
        var initialResponse = await _projectsPollingList.OnProjectsCreated(initialRequest);
        
        // Now use that complete memory for a second request
        var request = new PollingEventRequest<ProjectsMemory>
        {
            Memory = initialResponse.Memory,
            PollingTime = DateTime.UtcNow
        };

        // Act
        var response = await _projectsPollingList.OnProjectsCreated(request);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Memory);
        Assert.IsNotNull(response.Result);
        
        // Log for debugging
        Console.WriteLine($"Response: {JsonConvert.SerializeObject(response, Formatting.Indented)}");
        Console.WriteLine($"Projects found: {response.Result.Projects.Count}");
        
        // No new projects should be found since we're using the complete memory
        Assert.AreEqual(0, response.Result.Projects.Count, "No new projects should be found");
        Assert.IsFalse(response.FlyBird, "FlyBird should be false when no new projects are found");
    }



    //OnProjectStatusChanged (deprecated polling event, use OnGranularProjectStatusChanged)
    [TestMethod]
    public async Task OnProjectStatusChanged_ShouldBeSuccess()
    {
        // Arrange
        var request = new PollingEventRequest<ProjectStatusMemory>
        {
            Memory = null,
            PollingTime = DateTime.UtcNow.AddDays(-1) 
        };
        var projectStatus = new ProjectWithStatusRequest {ProjectId= "17b43bbd-932f-4c29-b8ee-79004dcfe920", Statuses = ["Invoiced", "Delivered"] };

        // Act
        var response = await _projectsPollingList.OnProjectStatusChanged(request, projectStatus);
        //Assert.IsFalse(response.FlyBird, "FlyBird should be false when no new projects are found");
        Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
        Assert.IsNotNull(response);
    }

    [DataTestMethod]
    [DataRow("PREVIOUS", "e46e7df2-a19c-4852-9014-10959007c05d", null, null, false, DisplayName = "Previous status and project ID provided")]
    [DataRow("undesired status", "e46e7df2-a19c-4852-9014-10959007c05d", null, null, false, DisplayName = "Wrong new status and project ID provided")]
    [DataRow("APPROVED", "e46e7df2-a19c-4852-9014-10959007c05d", "Sample reference", "blackbird", true, DisplayName = "All optional inputs provided")]
    [DataRow("APPROVED", null, null, null, true, DisplayName = "No optional inputs provided")]
    [DataRow("APPROVED", "e46e7df2-a19c-4852-9014-10959007c05d", null, null, true, DisplayName = "Project ID provided")]
    [DataRow("APPROVED", null, null, "Else;blackbird;", true, DisplayName = "Multiple tags provided")]
    [DataRow("APPROVED", null, "Sample reference", null, true, DisplayName = "Reference provided")]
    public async Task OnGranularProjectStatusChanged_ShouldBeSuccess(
        string status,
        string projectId,
        string reference,
        string tagsCsv,
        bool shouldFly)
    {
        // Arrange
        var memory = new ProjectStatusMemoryGranular
        {
            LastPollingTime = new DateTime(2025, 5, 10, 0, 0, 0, DateTimeKind.Utc),
            ProjectsPreviousStatus = new Dictionary<string, string>
            {
                { "e46e7df2-a19c-4852-9014-10959007c05d", "PREVIOUS" } // Simulate a previous status
            }
        };

        var request = new PollingEventRequest<ProjectStatusMemoryGranular>
        {
            Memory = memory,
            PollingTime = DateTime.UtcNow.AddDays(-1)
        };

        var statusRequest = new ProjectWithStatusGranularRequest
        {
            Statuses = new List<string> { status },
            ProjectId = projectId,
            Reference = reference,
            Tags = string.IsNullOrEmpty(tagsCsv) ? new List<string>() : tagsCsv.Split(';').ToList()
        };

        // Act
        var response = await _projectsPollingList.OnGranularProjectStatusChanged(request, statusRequest);

        // Log for debugging
        // Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));

        // Assert
        Assert.IsNotNull(response);
        Assert.AreEqual(shouldFly, response.FlyBird, "response.FlyBird response is not expected.");
    }
}
