namespace Apps.BWX.Dtos;

public class ClientDto
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public OrganizationDto Organization { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}