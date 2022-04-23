using BufeteAbogados.Data;
using BufeteAbogados.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BufeteAbogados.Servicios;

public class CitasServicio : ICitasServicio
{

    private readonly MySqlConfiguration _configuration;
    private CitasRepositorio citasRepositorio;

    public CitasServicio(MySqlConfiguration configuration)
    {
        _configuration = configuration;
        citasRepositorio = new CitasRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Eliminar(Citas citas)
    {
        return await citasRepositorio.Eliminar(citas);
    }

    public async Task<IEnumerable<Citas>> GetLista()
    {
        return await citasRepositorio.GetLista();
    }

    public async Task<Citas> GetPorCodigo(string codigo)
    {
        return await citasRepositorio.GetPorCodigo(codigo);
    }

    public async Task<Abogados> GetPorCodigoAbogados(string codigo)
    {
        return await citasRepositorio.GetPorCodigoAbogados(codigo);
    }

    public async Task<Cliente> GetPorCodigoClientes(string codigo)
    {
        return await citasRepositorio.GetPorCodigoClientes(codigo);
    }

    public async Task<bool> Nuevo(Citas citas)
    {
        return await citasRepositorio.Nuevo(citas);
    }
}
