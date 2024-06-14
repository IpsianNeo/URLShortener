using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace URLShortener.Services;

public class UrlShorteningService
{
    public const int NumberOfCharsInShortLink = 7;
    private const string AlphaNumerics = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private readonly Random _random = new Random();
    private readonly ApplicationDbContext _dbContext;

    public UrlShorteningService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> GenerateUniqueCode()
    {
        var codeChars = new char[NumberOfCharsInShortLink];

        while (true)
        {
            for (int i = 0; i < NumberOfCharsInShortLink; i++)
            {
                int randomIndex = _random.Next(AlphaNumerics.Length - 1);
                codeChars[i] = AlphaNumerics[randomIndex];
            }

            var code = new string(codeChars);

            if (!await _dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
            {
                return code;
            }
        }

    }
}
