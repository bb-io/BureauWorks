using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.DataSourceHandlers.EnumDataHandlers
{
    public class ProjectStatusDataHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
            {
                {"Draft", "Draft"},
                {"Pending", "Pending"},
                {"Approved", "Approved"},
                {"Delivered", "Delivered"},
                {"Invoiced", "Invoiced"},
            };
    }
}
