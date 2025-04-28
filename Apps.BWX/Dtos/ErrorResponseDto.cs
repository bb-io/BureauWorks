namespace Apps.BWX.Dtos;

public class ErrorResponseDto
{
    public int Status { get; set; }
    public string Exception { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}
