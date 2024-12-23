namespace Movies.Contracts.Responses;

public sealed class ValidationFailureResponse
{
    public required IEnumerable<ValidationResponse> Errors { get; set; }
}