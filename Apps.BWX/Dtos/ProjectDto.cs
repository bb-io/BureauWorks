using Blackbird.Applications.Sdk.Common;

namespace Apps.BWX.Dtos;

public class ProjectDto
{
    [Display("UUID")]
    public string Uuid { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }

    [Display("Genesis ID")]
    public string GenesisId { get; set; }
    public string Currency { get; set; }

    [Display("Source locale")]
    public string SourceLocale { get; set; }

    [Display("Target locales")]
    public List<string> TargetLocales { get; set; }

    [Display("Is continuous")]
    public bool IsContinuous { get; set; }

    [Display("Create date")]
    public long CreateDate { get; set; }

    [Display("Due date")]
    public long DueDate { get; set; }
    public string Status { get; set; }
    public Client Client { get; set; }
    public Contact Contact { get; set; }
    public Creator Creator { get; set; }
    public List<string> Tags { get; set; }
    public List<Cost> Costs { get; set; }

    [Display("Reference files")]
    public List<string> ReferenceFiles { get; set; }

    [Display("Drop files")]
    public List<string> DropFiles { get; set; }

    [Display("Costs log file ID")]
    public string CostsLogfileId { get; set; }

    [Display("Costs status")]
    public string CostsStatus { get; set; }

    [Display("Costs calculated at")]
    public long CostsCalculatedAt { get; set; }

    [Display("Total work units")]
    public int TotalWorkUnits { get; set; }
    public double Progress { get; set; }
    public bool AutomationEnabled { get; set; }

    [Display("Automation status")]
    public string AutomationStatus { get; set; }
}

public class Client
{
    [Display("UUID")]
    public string Uuid { get; set; }
    public OrganizationDto Organization { get; set; }
    public string Name { get; set; }

    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [Display("Target languages")]
    public List<string> TargetLanguages { get; set; }
}

public class Contact
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }

    [Display("Tasks completed count")]
    public int TasksCompletedCount { get; set; }

    [Display("UUID")]
    public string Uuid { get; set; }
}

public class Cost
{
    [Display("ID")]
    public int Id { get; set; }

    [Display("UUID")]
    public string Uuid { get; set; }
    public string Description { get; set; }

    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [Display("Target language")]
    public string TargetLanguage { get; set; }
    public string Filename { get; set; }
    public string Reason { get; set; }

    [Display("Costs log file ID")]
    public string CostsLogfileId { get; set; }

    [Display("Creation timestamp")]
    public long CreationTimestamp { get; set; }

    [Display("Match start")]
    public int MatchStart { get; set; }

    [Display("Match end")]
    public int MatchEnd { get; set; }

    [Display("Display order")]
    public string DisplayOrder { get; set; }

    [Display("Unit type")]
    public string UnitType { get; set; }
    public int Units { get; set; }

    [Display("Cost per unit")]
    public double CostPerUnit { get; set; }
    public double Total { get; set; }

    [Display("Rate type")]
    public string RateType { get; set; }

    [Display("Cost type")]
    public string CostType { get; set; }
}

public class Creator
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }

    [Display("Tasks completed count")]
    public int TasksCompletedCount { get; set; }

    [Display("UUID")]
    public string Uuid { get; set; }
}