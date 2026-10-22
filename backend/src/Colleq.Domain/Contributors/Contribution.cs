namespace Colleq.Domain.Contributors;

public class Contribution
{
    public Guid Id { get; }
    public Guid ContributorId { get; }
    public ContributionRole Role { get; }

    public Contribution(Guid contributorId, ContributionRole role)
    {
        if (contributorId == Guid.Empty)
        {
            throw new ArgumentException("Contributor ID cannot be empty.", nameof(contributorId));
        }
        
        ArgumentNullException.ThrowIfNull(role);

        Id = Guid.NewGuid();
        ContributorId = contributorId;
        Role = role;
    }
}