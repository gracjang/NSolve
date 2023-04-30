namespace NSolve.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }

    public string Token { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime GenerateTime { get; set; }

    public string Status { get; set; }

    public Guid DrawId { get; set; }

    public Draw Draw { get; set; } = null!;

}