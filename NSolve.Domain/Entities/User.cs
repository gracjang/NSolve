namespace NSolve.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public string Type { get; set; } = default!;

    public ICollection<Draw> Draws { get; set; } = default!;
}