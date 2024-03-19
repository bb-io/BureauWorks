using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class ProjectDto
    {
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string GenesisId { get; set; }
        public string Currency { get; set; }
        public string SourceLocale { get; set; }
        public List<string> TargetLocales { get; set; }
        public bool IsContinuous { get; set; }
        public long CreateDate { get; set; }
        public long DueDate { get; set; }
        public string Status { get; set; }
        public Client Client { get; set; }
        public Contact Contact { get; set; }
        public Creator Creator { get; set; }
        public List<string> Tags { get; set; }
        public List<Cost> Costs { get; set; }
        public List<string> ReferenceFiles { get; set; }
        public List<string> DropFiles { get; set; }
        public string CostsLogfileId { get; set; }
        public string CostsStatus { get; set; }
        public long CostsCalculatedAt { get; set; }
        public int TotalWorkUnits { get; set; }
        public double Progress { get; set; }
        public bool AutomationEnabled { get; set; }
        public string AutomationStatus { get; set; }
    }

    public class Client
    {
        public string Uuid { get; set; }
        public Organization Organization { get; set; }
        public string Name { get; set; }
        public string SourceLanguage { get; set; }
        public List<string> TargetLanguages { get; set; }
    }

    public class Contact
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int TasksCompletedCount { get; set; }
        public string Uuid { get; set; }
    }

    public class Cost
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Description { get; set; }
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public string Filename { get; set; }
        public string Reason { get; set; }
        public string CostsLogfileId { get; set; }
        public long CreationTimestamp { get; set; }
        public int MatchStart { get; set; }
        public int MatchEnd { get; set; }
        public string DisplayOrder { get; set; }
        public string UnitType { get; set; }
        public int Units { get; set; }
        public double CostPerUnit { get; set; }
        public double Total { get; set; }
        public string RateType { get; set; }
        public string CostType { get; set; }
    }

    public class Creator
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int TasksCompletedCount { get; set; }
        public string Uuid { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
