namespace Movies.Contracts.Responses;

public sealed class ValidationResponse
{
    public  string PropertyName { get; init; }
    public  string Message { get; init; }
}