using BufeteAbogados.Data;
using Datos.Interfaces;
using Datos.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;

namespace BufeteAbogados.Controles;

public class LoginControles : Controller
{
    private readonly MySqlConfiguration _configuration;
    private IUsuarioRepositorio _usuarioRepositorio;

    public LoginControles(MySqlConfiguration configuration)
    {
        _configuration = configuration;
        _usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
    }

    [HttpPost("/account/login")]

    public async Task<IActionResult> Login(Login login)
    {
        try
        {
            bool usuarioValido = await _usuarioRepositorio.ValidarUsuario(login);
            if (usuarioValido)
            {
                Usuario usu = await _usuarioRepositorio.GetPorCodigo(login.Codigo);
                if (usu.EstaActivo)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, usu.Codigo)
                    };

                    var claimsIdentify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentify);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(20) });
                }
                else
                {
                    return LocalRedirect("/login/Usuario Inactivo");
                }
            }
            else
            {
                return LocalRedirect("/login/Datos no validos");
            }
        }
        catch (Exception ex)
        {
            return LocalRedirect("/login/Datos no validos");
        }
        return LocalRedirect("/");
    }

    [HttpGet("/account/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return LocalRedirect("/");
    }
}
