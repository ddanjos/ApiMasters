using ApiMasters.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMasters.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Artista> Artistas => Set<Artista>();
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Musica> Musicas => Set<Musica>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nome = "Rock" },
                new Genero { Id = 2, Nome = "Pop" },
                new Genero { Id = 3, Nome = "MPB" },
                new Genero { Id = 4, Nome = "Jazz" },
                new Genero { Id = 5, Nome = "Blues" },
                new Genero { Id = 6, Nome = "Heavy Metal" },
                new Genero { Id = 7, Nome = "Hip Hop" },
                new Genero { Id = 8, Nome = "Rap" },
                new Genero { Id = 9, Nome = "Trap" },
                new Genero { Id = 10, Nome = "Reggae" },
                new Genero { Id = 11, Nome = "Samba" },
                new Genero { Id = 12, Nome = "Pagode" },
                new Genero { Id = 13, Nome = "Sertanejo" },
                new Genero { Id = 14, Nome = "Funk" },
                new Genero { Id = 15, Nome = "Axé" },
                new Genero { Id = 16, Nome = "Forró" },
                new Genero { Id = 17, Nome = "Bossa Nova" },
                new Genero { Id = 18, Nome = "Música Clássica" },
                new Genero { Id = 19, Nome = "Eletrônica" },
                new Genero { Id = 20, Nome = "House" },
                new Genero { Id = 21, Nome = "Techno" },
                new Genero { Id = 22, Nome = "Indie" },
                new Genero { Id = 23, Nome = "Punk" },
                new Genero { Id = 24, Nome = "Country" },
                new Genero { Id = 25, Nome = "R&B" },
                new Genero { Id = 26, Nome = "Soul" },
                new Genero { Id = 27, Nome = "Gospel" },
                new Genero { Id = 28, Nome = "Lo-Fi" },
                new Genero { Id = 29, Nome = "K-Pop" },
                new Genero { Id = 30, Nome = "Reggaeton" }
            );

            modelBuilder.Entity<Artista>().HasData(
                new Artista { Id = 1, Nome = "Queen", Nacionalidade = "Britânica" },
                new Artista { Id = 2, Nome = "Tim Maia", Nacionalidade = "Brasileira" },
                new Artista { Id = 3, Nome = "Daft Punk", Nacionalidade = "Francesa" }
            );
            
            modelBuilder.Entity<Musica>().HasData(
                new Musica { Id = 1, Nome = "Bohemian Rhapsody", Duracao = 354, ArtistaId = 1 },
                new Musica { Id = 2, Nome = "Don't Stop Me Now", Duracao = 209, ArtistaId = 1 },
                new Musica { Id = 3, Nome = "O Descobridor dos Sete Mares", Duracao = 264, ArtistaId = 2 },
                new Musica { Id = 4, Nome = "Get Lucky", Duracao = 248, ArtistaId = 3 }
            );

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.Property(a => a.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(a => a.Nacionalidade)
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Musica>(entity =>
            {
                entity.Property(m => m.Nome)
                      .IsRequired()
                      .HasMaxLength(150);
            });

            modelBuilder.Entity<Musica>()
                .HasMany(m => m.Generos)
                .WithMany(g => g.Musicas)
                .UsingEntity(j => 
                {
                    j.ToTable("MusicasGeneros");
                    
                    j.HasData(
                        new { MusicasId = 1, GenerosId = 1 },  
                        new { MusicasId = 1, GenerosId = 2 },  
                        new { MusicasId = 2, GenerosId = 1 }, 
                        new { MusicasId = 3, GenerosId = 3 },
                        new { MusicasId = 3, GenerosId = 26 },
                        new { MusicasId = 4, GenerosId = 19 } 
                    );
                });

            modelBuilder.Entity<Musica>()
                .HasOne(m => m.Artista)
                .WithMany(a => a.Musicas)
                .HasForeignKey(m => m.ArtistaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}