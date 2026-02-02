namespace TaskManager.API.Contracts
{
    internal class ValidationErrorResponse : ApiErrorResponse
    {
        public Dictionary<string, string[]> Errors { get; init; } = [];
    }
}
