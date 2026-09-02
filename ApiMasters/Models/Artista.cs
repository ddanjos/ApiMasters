namespace ApiMasters.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    }
}
