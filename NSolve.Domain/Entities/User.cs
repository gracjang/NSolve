namespace NSolve.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Type { get; set; }

    public ICollection<Draw> Draws { get; set; } = null!;
}