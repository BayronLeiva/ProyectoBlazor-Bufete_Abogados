using BufeteAbogados.Data;
using BufeteAbogados.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BufeteAbogados.Servicios;

public class AbogadoServicio : IAbogadoServicio
{

    private readonly MySqlConfiguration _configuration;
    private AbogadoRepositorio abogadoRepositorio;

    public AbogadoServicio(MySqlConfiguration configuration)
    {
        _configuration = configuration;
        abogadoRepositorio = new AbogadoRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Actualizar(Abogados abogado)
    {
        return await abogadoRepositorio.Actualizar(abogado);
    }

    public async Task<bool> Eliminar(Abogados abogado)
    {
        return await abogadoRepositorio.Eliminar(abogado);
    }

    public async Task<IEnumerable<Abogados>> GetLista()
    {
        return await abogadoRepositorio.GetLista();
    }

    public async Task<Abogados> GetPorCodigo(string codigo)
    {
        return await abogadoRepositorio.GetPorCodigo(codigo);
    }

    public async Task<bool> Nuevo(Abogados abogado)
    {
        return await abogadoRepositorio.Nuevo(abogado);
    }
}
