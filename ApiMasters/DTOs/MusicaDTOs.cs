using ApiMasters.Models;

namespace ApiMasters.DTOs;

public class MusicaCriacaoDto
{
    public string Nome { get; set; } = string.Empty;
    public int ArtistaId { get; set; }
    public int Duracao {get; set;}
    public List<int> GenerosIds { get; set; } =  new();

}

public class MusicaRespostaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int ArtistaId  { get; set; }
    public List<GeneroRespostaDto> Generos { get; set; } = new();
    
    public int Duracao { get; set; }
}