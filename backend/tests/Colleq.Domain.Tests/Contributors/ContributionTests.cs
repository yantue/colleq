using Colleq.Domain.Contributors;

namespace Colleq.Domain.Tests.Contributors;

public class ContributionTests
{
    [Fact]
    public void Constructor_WithValidArguments_CreatesContribution()
    {
        Guid id = Guid.NewGuid();
        ContributionRole role = new ContributionRole("Director");

        Contribution contribution = new Contribution(id, role);
        
        Assert.NotEqual(Guid.Empty, contribution.Id);
        Assert.Equal(id, contribution.ContributorId);
        Assert.Equal(role, contribution.Role);
    }

    [Fact]
    public void Constructor_WithEmptyContributorId_ThrowsException()
    {
        ContributionRole role = new ContributionRole("Director");

        Assert.Throws<ArgumentException>(() => new Contribution(Guid.Empty, role));
    }

    [Fact]
    public void Constructor_WithNullRole_ThrowsNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Contribution(Guid.NewGuid(), null!));
    }
}