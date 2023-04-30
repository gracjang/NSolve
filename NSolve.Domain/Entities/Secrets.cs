namespace NSolve.Domain.Entities;

public class Secrets
{
    public Guid Id { get; set; }

    public string AdminSecret { get; set; }

    public string JoinerSecret { get; set; }

    public DateTime Created { get; set; }

    public bool Expired { get; set; }

    public Guid DrawId { get; set; }

    public Draw Draw { get; set; } = null!;
}