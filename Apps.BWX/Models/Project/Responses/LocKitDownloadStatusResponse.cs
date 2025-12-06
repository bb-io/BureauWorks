namespace Apps.BWX.Models.Project.Responses;

public class LocKitDownloadStatusResponse
{
    public string Id { get; set; }
    public string Status { get; set; }
    public string DownloadFileUrl { get; set; }
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public long CreationDate { get; set; }
    public string Type { get; set; }
}
