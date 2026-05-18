using PrintConnect.Domain.Enums;

namespace PrintConnect.Domain.Entities;

public class Printer: Entity
{
    public string Url { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public PrinterStatus Status { get; set; }

    private Printer()
    {
        Url = string.Empty;
        Username = string.Empty;
        Password = string.Empty;
        Name = string.Empty;
        Description = string.Empty;
        Model = string.Empty;
    }
    public static Printer Create()
    {
        //TODO: fix
        return new Printer();
    }
}