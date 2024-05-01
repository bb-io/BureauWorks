using Apps.BWX.DataSourceHandlers;
using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.BWX.Models.Project.Requests;

public class SearchProjectRequest
{
    [Display("Project name", Description = "Project name, for example: \"B-2478-1111\"")]
    public string? ProjectName { get; set; }

    [Display("Organization")]
    [DataSource(typeof(OrganizationDataHandler))]
    public string? Organization { get; set; }

    [Display("Organization unit")]
    [DataSource(typeof(ClientDataHandler))]
    public string? Client { get; set; }

    [Display("Project manager")]
    [DataSource(typeof(ProjectManagerDataHandler))]
    public string? ProjectManager { get; set; }

    [Display("Contact person")]
    [DataSource(typeof(UserDataHandler))]
    public string? ContactPerson { get; set; }

    [Display("Reference")]
    public string? Reference { get; set; }

    [Display("Project statuses")]
    [StaticDataSource(typeof(ProjectStatusDataHandler))]
    public List<string>? ProjectStatuses { get; set; }

    [Display("Creation date start")]
    public DateTime? CreationDateStart { get; set; }

    [Display("Creation date end")]
    public DateTime? CreationDateEnd { get; set; }

    [Display("Due date start")]
    public DateTime? DueDateStart { get; set; }

    [Display("Due date end")]
    public DateTime? DueDateEnd { get; set; }

    [Display("Tags")]
    public List<string>? Tags { get; set; }
}