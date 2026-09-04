namespace ApiMasters.DTOs;

public class ArtistaCriacaoDto
{
    public string Nome { get; set; } = string.Empty;
    public string Nacionalidade { get; set; } = string.Empty;
}

public class ArtistaRespostaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Nacionalidade { get; set; } = string.Empty;
}