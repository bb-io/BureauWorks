using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.BWX.Dtos
{
    public class ProjectFileInfoDto
    {
        public string Uuid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Hash { get; set; }
        public string Notes { get; set; }
        public string SourceLocale { get; set; }
        public int Creation { get; set; }
        public string ProjectUuid { get; set; }
        public Params Params { get; set; }
        public List<string> Workflows { get; set; }
        public List<string> TargetLocales { get; set; }
    }

    public class Params
    {
        public string ProjectResourceId { get; set; }
        public string ApplySourceSegmentation { get; set; }
        public string Parameters { get; set; }
        public string ParserFilter { get; set; }
        public string TagRegex { get; set; }
    }

}
