namespace PrintConnect.Domain.Entities;

public class Job: Entity
{
    public string Name { get; set; }
    public string FileName { get; set; }
    public Printer Printer { get; set; }
    public Guid PrinterId { get; set; }
    public int SequenceNumber { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
}