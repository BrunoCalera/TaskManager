namespace TaskManager.API.Contracts
{
    internal class ApiErrorResponse
    {
        public string Title { get; init; } = string.Empty;
        public int Status { get; init; }
        public string? Detail { get; init; }
    }
}
