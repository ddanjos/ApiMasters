namespace ApiMasters.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Duracao { get; set; }

        public int ArtistaId { get; set; }
        public Artista? Artista { get; set; }

        public ICollection<Genero> Generos { get; set; } = new List<Genero>();

    }
}
