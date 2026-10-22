namespace Colleq.Domain.ValueObjects;

public sealed record Country
{
    public string Code { get; } // ISO 3166-1 alpha-2 https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2

    public Country(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);

        code = code.Trim();

        if (code.Length != 2 || !code.All(char.IsAsciiLetter))
        {
            throw new ArgumentException("Country code must be a two-letter ISO 3166-1 alpha-2 code.", nameof(code));
        }

        Code = code.ToUpperInvariant();
    }
}