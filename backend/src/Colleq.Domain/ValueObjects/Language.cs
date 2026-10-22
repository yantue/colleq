using System.Globalization;

namespace Colleq.Domain.ValueObjects;

public sealed record Language
{
    public string Code { get; } // IETF BCP 47 language tag https://en.wikipedia.org/wiki/IETF_language_tag

    public Language(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);

        code = code.Trim();

        try
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(code);
            Code = culture.Name;
        }
        catch (CultureNotFoundException e)
        {
            throw new ArgumentException("Language code must be a recognized .NET culture identifier.", nameof(code), e);
        }
    }
}