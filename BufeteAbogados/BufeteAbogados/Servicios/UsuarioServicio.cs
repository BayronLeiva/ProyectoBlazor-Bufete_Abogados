using BufeteAbogados.Data;
using BufeteAbogados.Interfaces;
using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BufeteAbogados.Servicios;

public class UsuarioServicio : IUsuarioServicio
{

    private readonly MySqlConfiguration _configuration;
    private IUsuarioRepositorio usuarioRepositorio;

    public UsuarioServicio(MySqlConfiguration configuration)
    {
        _configuration = configuration;
        usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Actualizar(Usuario usuario)
    {
        return await usuarioRepositorio.Actualizar(usuario);
    }

    public async Task<bool> Eliminar(Usuario usuario)
    {
        return await usuarioRepositorio.Eliminar(usuario);
    }

    public async Task<IEnumerable<Usuario>> GetLista()
    {
        return await usuarioRepositorio.GetLista();
    }

    public async Task<Usuario> GetPorCodigo(string codigo)
    {
        return await usuarioRepositorio.GetPorCodigo(codigo);
    }

    public async Task<bool> Nuevo(Usuario usuario)
    {
        return await usuarioRepositorio.Nuevo(usuario);
    }
}
