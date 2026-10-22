using Colleq.Domain.ValueObjects;

namespace Colleq.Domain.Tests.ValueObjects;

public class LanguageTests
{
    [Theory]
    [InlineData("EN-US", "en-US")]
    [InlineData(" en ", "en")]
    [InlineData("nl-BE", "nl-BE")]
    public void Construction_NormalizesCode(string input, string expected)
    {
        Language language = new Language(input);
        
        Assert.Equal(expected, language.Code);
    }

    [Fact]
    public void Languages_WithEquivalentCodes_AreEqual()
    {
        Assert.Equal(new Language("en-GB"), new Language("EN-GB"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("éN--GB")]
    public void Constructor_WithUnsupportedCultureCode_ThrowsException(string? code)
    {
        if (code == null)
        {
            Assert.Throws<ArgumentNullException>(() => new Language(code!));
            return;
        } 
        Assert.Throws<ArgumentException>(() => new Language(code!));
    }
}