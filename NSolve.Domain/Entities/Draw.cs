using System.ComponentModel.DataAnnotations.Schema;

namespace NSolve.Domain.Entities;

public class Draw
{
    public Guid Id { get; set; }

    public Secrets DrawSecrets { get; set; }

    public ICollection<User> Users { get; set; } = null!;

    public ICollection<Notification> Notifications { get; set; } = null!;
    public string Status { get; set; }

    public Dictionary<string, string>? Results { get; set; }
}