using Colleq.Domain.ValueObjects;

namespace Colleq.Domain.Tests.ValueObjects;

public class CountryTests
{
    [Theory]
    [InlineData("ie", "IE")]
    [InlineData(" IT ", "IT")]
    [InlineData("nl", "NL")]
    public void Construction_NormalizesCode(string input, string expected)
    {
        Country country = new Country(input);
        
        Assert.Equal(expected, country.Code);
    }

    [Fact]
    public void Countries_WithEquivalentCodes_AreEqual()
    {
        Assert.Equal(new Country("au"), new Country("AU"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("USA")]
    [InlineData("éU")]
    [InlineData("I")]
    [InlineData("B3")]
    public void Constructor_WithInvalidCode_ThrowsException(string? code)
    {
        if (code == null)
        {
            Assert.Throws<ArgumentNullException>(() => new Country(code!));
            return;
        } 
        Assert.Throws<ArgumentException>(() => new Country(code!));
    }
}