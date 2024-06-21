namespace TechnicalInsulation.Models.Elements;

public abstract class Element
{
    protected Element()
    {
        
    }
    
    protected Element(string drawing, int number, decimal temperature, decimal length, Scope scope)
    {
        Length = length;
        Scope = scope;
        Temperature = temperature;
        Drawing = drawing;
        Number = number;
        scope.Elements.Add(this);
        scope.ElementDictionary.Add((drawing, number), this);
    }

    public int ScopeId { get; init; }
    public string Drawing { get; init; } = null!;
    public int Number { get; init; }
    public decimal Temperature { get; init; }
    public decimal Length { get; init; }
    public Scope Scope { get; init; } = null!;
    public int ProductId { get; init; }
    public Product? Product { get; set; }
}