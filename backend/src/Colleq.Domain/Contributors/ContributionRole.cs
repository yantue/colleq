namespace Colleq.Domain.Contributors;

public sealed record ContributionRole
{
    public string Name { get; }
    
    public ContributionRole(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name.Trim();
    }
}