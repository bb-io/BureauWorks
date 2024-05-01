namespace Apps.BWX.Dtos
{
    public class GlossaryDto
    {
        public string Uuid { get; set; }
        public int BwGlossaryId { get; set; }
        public string Name { get; set; }
        public long CreationDate { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public List<ClientDto> OrgUnits { get; set; }
        public OrganizationDto Organization { get; set; }
        public string Note { get; set; }
        public bool IsDefault { get; set; }
        public int TotalConcepts { get; set; }
        public List<string> Languages { get; set; }
        public List<string> AllLanguages { get; set; }
    }

    public class CreatedBy
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int TasksCompletedCount { get; set; }
        public string Uuid { get; set; }
    }
}
