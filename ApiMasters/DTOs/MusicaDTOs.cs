using System.ComponentModel.DataAnnotations;

namespace ApiMasters.DTOs;

public class MusicaCriacaoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 255 caracteres.")]
    public string Nome { get; set; } = string.Empty;


    [Required(ErrorMessage = "Um artista deve ser informado.")]
    public int ArtistaId { get; set; }


    [Required(ErrorMessage = "A duração é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A duração precisa ser maior que zero.")]
    public int Duracao {get; set;}

    [Required(ErrorMessage = "Pelo menos um gênero deve ser informado.")]
    public List<int> GenerosIds { get; set; } =  new();

}

public class MusicaRespostaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Duracao { get; set; }
    public int ArtistaId { get; set; }
    public List<GeneroRespostaDto> Generos { get; set; } = new();
}

public class MusicaAlteracaoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 255 caracteres.")]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "Um artista deve ser informado.")]
    public int ArtistaId { get; set; }
    [Required(ErrorMessage = "A duração é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A duração precisa ser maior que zero.")]
    public int Duracao { get; set; }

    [Required(ErrorMessage = "Pelo menos um gênero deve ser informado.")]
    public List<int> GenerosIds { get; set; } = new();
}