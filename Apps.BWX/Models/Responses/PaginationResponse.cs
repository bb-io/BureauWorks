namespace Apps.BWX.Models.Responses;

public class PaginationResponse<T>
{
    public virtual IEnumerable<T> Content { get; set; }
    
    public bool Last { get; set; }
}