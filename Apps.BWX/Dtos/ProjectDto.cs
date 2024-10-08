using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Dtos;

public class ProjectDto
{
    [Display("Project ID")]
    public string Uuid { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Reference { get; set; } = default!;

    [Display("Genesis ID")]
    public string GenesisId { get; set; } = default!;
    
    public string Currency { get; set; } = default!;

    [Display("Source locale")]
    public string SourceLocale { get; set; }

    [Display("Target locales")]
    public List<string> TargetLocales { get; set; } = default!;

    [Display("Is continuous?")]
    public bool IsContinuous { get; set; }

    //[Display("Create date")]
    //public long CreateDate { get; set; }

    //[Display("Due date")]
    //public long DueDate { get; set; }
    public string Status { get; set; } = default!;
    
    public Client Client { get; set; } = default!;
    
    public Contact Contact { get; set; } = default!;
    
    public Creator Creator { get; set; } = default!;
    
    public List<string> Tags { get; set; } = default!;
    
    public List<Cost> Costs { get; set; } = default!;

    [Display("Reference files")]
    public List<string> ReferenceFiles { get; set; } = default!;

    [Display("Drop files")]
    public List<string> DropFiles { get; set; } = default!;

    [Display("Costs log file ID")]
    public string CostsLogfileId { get; set; } = default!;

    [Display("Costs status")]
    public string CostsStatus { get; set; } = default!;

    [Display("Costs calculated at")]
    public long CostsCalculatedAt { get; set; } = default!;

    [Display("Total work units")]
    public int TotalWorkUnits { get; set; } = default!;
    
    public double Progress { get; set; } = default!;
    
    [Display("Automation enabled")]
    public bool AutomationEnabled { get; set; } = default!;

    [Display("Automation status")]
    public string AutomationStatus { get; set; } = default!;
}

public class Client
{
    [Display("Client ID")]
    public string Uuid { get; set; }  = default!;
    
    public OrganizationDto Organization { get; set; } = default!;
    
    public string Name { get; set; } = default!;

    [Display("Source language")]
    public string SourceLanguage { get; set; } = default!;

    [Display("Target languages")]
    public List<string> TargetLanguages { get; set; } = default!;
}

public class Contact
{
    [Display("Contact ID")]
    public string Uuid { get; set; } = default!;

    public string Email { get; set; } = default!;
    
    public string Name { get; set; } = default!;
    
    public string Status { get; set; } = default!;

    [Display("Tasks completed count")]
    public int TasksCompletedCount { get; set; }

}

public class Cost
{
    //[Display("ID")]
    //public int Id { get; set; }

    [Display("Cost ID")]
    public string Uuid { get; set; } = default!;
    
    public string Description { get; set; } = default!;

    [Display("Source language")]
    public string SourceLanguage { get; set; } = default!;

    [Display("Target language")]
    public string TargetLanguage { get; set; } = default!;
    
    [Display("File name")]
    public string Filename { get; set; } = default!;
    
    public string Reason { get; set; } = default!;

    [Display("Costs log file ID")]
    public string CostsLogfileId { get; set; } = default!;

    //[Display("Creation timestamp")]
    //public long CreationTimestamp { get; set; }

    [Display("Match start")]
    public int MatchStart { get; set; }

    [Display("Match end")]
    public int MatchEnd { get; set; }

    [Display("Display order")]
    public string DisplayOrder { get; set; } = default!;

    [Display("Unit type")]
    public string UnitType { get; set; } = default!;
    
    public int Units { get; set; }

    [Display("Cost per unit")]
    public double CostPerUnit { get; set; }
    
    public double Total { get; set; }

    [Display("Rate type")]
    public string RateType { get; set; } = default!;

    [Display("Cost type")]
    public string CostType { get; set; } = default!;
}

public class Creator
{
    [Display("Creator ID")]
    public string Uuid { get; set; } = default!;
    
    public string Email { get; set; } = default!;
    
    public string Name { get; set; } = default!;
    
    public string Status { get; set; } = default!;

    [Display("Tasks completed count")]
    public int TasksCompletedCount { get; set; }
}