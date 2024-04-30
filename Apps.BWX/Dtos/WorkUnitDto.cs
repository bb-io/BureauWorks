namespace Apps.BWX.Dtos;

public class WorkUnitDto
{
    public string Uuid { get; set; }
    public string WorkId { get; set; }
    public string Name { get; set; }
    public string SourceLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string Filename { get; set; }
    public long CreationTimestamp { get; set; }
    public long LastUpdate { get; set; }
    public int Sequence { get; set; }
    public string Workflow { get; set; }
    public string ProjectUUID { get; set; }
    public string ProjectResourceUuid { get; set; }
}