using Microsoft.EntityFrameworkCore;
using URLShortener.Entities;
using URLShortener.Services;

namespace URLShortener;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortenedUrl>(builder =>
        {
            builder.Property(s => s.Code).HasMaxLength(UrlShorteningService.NumberOfCharsInShortLink);
            builder.HasIndex(s => s.Code).IsUnique();
        });
    }
}
