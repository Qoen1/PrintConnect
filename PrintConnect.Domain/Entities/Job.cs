namespace PrintConnect.Domain.Entities;

public class Job: Entity
{
    public string Name { get; set; }
    public string FileName { get; set; }
    public int Progress { get; set; }
    public Printer Printer { get; set; }
}