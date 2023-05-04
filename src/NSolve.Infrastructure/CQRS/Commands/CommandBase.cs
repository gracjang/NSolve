using System.Text.Json.Serialization;

namespace NSolve.Infrastructure.CQRS.Commands;

public abstract class CommandBase
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Error? Error { get; set; }

    public bool IsSuccess => Error != null;
}