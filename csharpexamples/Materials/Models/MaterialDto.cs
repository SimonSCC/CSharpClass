namespace LEGO.CSharpExamples.Materials.Models;

public record MaterialDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Volume { get; set; }
}