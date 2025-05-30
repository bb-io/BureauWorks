﻿using Apps.BWX.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.BWX.Models.Project.Requests;

public class ProjectWithStatusRequest : GetProjectRequest
{
    [Display("Status"), StaticDataSource(typeof(ProjectStatusDataHandler))]
    public IEnumerable<string> Statuses { get; set; } = new List<string>();
}