using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Models  
{
    public class ConfigureGenres : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            entity.HasData(
                new { GenreId = "novel", Name = "Novel" },
                new { GenreId = "history", Name = "History" },
                new { GenreId = "scifi", Name = "Scifi" },
                new { GenreId = "memoir", Name = "Memoir" },
                 new { GenreId = "mystery", Name = "Mystery" }

                );
        }
    }
}
