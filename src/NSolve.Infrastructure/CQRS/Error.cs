namespace NSolve.Infrastructure.CQRS;

public sealed class Error
{

    public Error(string? type, string? title, string? details)
    {
        Type = type;
        Title = title;
        Details = details;
    }

    public string? Type { get; set; }

    public string? Title { get; set; }

    public string? Details { get; set; }
}