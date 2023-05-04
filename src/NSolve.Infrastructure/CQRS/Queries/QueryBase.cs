using System.Text.Json.Serialization;

namespace NSolve.Infrastructure.CQRS.Queries;

public abstract class QueryBase<TResult>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Error? Error { get; set; }

    public bool IsSuccess => Error != null;

    TResult Result { get; set; } = default!;
}