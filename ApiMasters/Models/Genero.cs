namespace ApiMasters.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        
        public ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
