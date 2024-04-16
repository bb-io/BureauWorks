namespace Apps.BWX.Dtos;

public class ProjectFileInfoDto
{
    public string Uuid { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Notes { get; set; }
    public long Creation { get; set; }
    public string ProjectUuid { get; set; }
    public Params Params { get; set; }
    public bool DefaultFilterSettings { get; set; }
}

public class Params
{
    public bool ApplySourceSegmentation { get; set; }
    public bool ExtractTerms { get; set; }
    public TermsParams TermsParams { get; set; }
    public string ParserFilter { get; set; }
}

public class TermsParams
{
    public bool KeepCase { get; set; }
    public int MinWordsPerTerm { get; set; }
    public bool SortByOccurrence { get; set; }
    public bool RemoveSubTerms { get; set; }
    public int MinOccurrences { get; set; }
    public int MaxWordsPerTerm { get; set; }
    public int TopTermsLimit { get; set; }
}