namespace Apps.BWX.Models.Project.Responses;

public class PaginationResponse<T>
{
    public virtual IEnumerable<T> Content { get; set; }

    public bool Last { get; set; }
}