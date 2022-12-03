namespace PM3Other;

public class Team
{
    public string Name { get; init; } = null!;
    public string Country { get; init; } = null!;
    public string City { get; init; } = null!;

    public override string ToString()
    {
        return $"{Name} {City}, {Country}";
    }
}