namespace PrintConnect.Domain.Entities;

public class Material: Entity
{
    public string Name { get; set; }
    public MaterialType MaterialType { get; set; }
}