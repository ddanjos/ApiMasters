
    using ApiMasters.Models;
    using Microsoft.AspNetCore.Identity.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    namespace ApiMasters.Controllers;

[ApiController]
[Route("api/[controller]")] // <--- O erro está aqui!
public class AuthController(IConfiguration config) : ControllerBase
{
        private static readonly List<Usuario> _usuarios =
        [
        new("Celia Csharp", "123", "Admin"),
        new("Asaaf Asp.Net", "124", "Aluno")
        ];




    [HttpPost("login")]
    public IActionResult Login(LoginDto req)
    {
        var usuario = _usuarios.FirstOrDefault(u => req.login == u.User && req.password == u.Password);
        if (usuario is null) return Unauthorized("Login ou senha inválidos");

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, usuario.User),
        new Claim("role", usuario.Role)
    };

        // CHAVE FIXA DE TESTE (Mais de 32 caracteres)
        var secretKey = "chave_super_secreta_fixa_para_testes_1234567890_abcde";
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var token = new JwtSecurityToken(
            issuer: config["JWT:Issuer"],
            audience: config["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: new SigningCredentials(chave, SecurityAlgorithms.HmacSha256)
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    public record LoginDto(String login, string password);


    }
