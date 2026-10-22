using Colleq.Domain.Contributors;

namespace Colleq.Domain.Tests.Contributors;

public class ContributionRoleTests
{
    [Theory]
    [InlineData(" Director ")]
    [InlineData("Director\n")]
    public void Constructor_TrimsWhitespaceFromName(string directorName)
    {
        ContributionRole director = new ContributionRole(directorName);
        
        Assert.Equal("Director", director.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData("\r")]
    public void Constructor_RejectsInvalidName(string name)
    {
        Assert.Throws<ArgumentException>(() => new ContributionRole(name));
    }

    [Fact]
    public void Equality_UsesNormalizedName()
    {
        ContributionRole director1 = new ContributionRole("Director");
        ContributionRole director2 = new ContributionRole(" Director ");
        
        Assert.Equal(director1, director2);
    }
}
