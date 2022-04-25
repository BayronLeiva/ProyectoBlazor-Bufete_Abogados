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

    public async Task<bool> Eliminar(Cita citas)
    {
        return await citasRepositorio.Eliminar(citas);
    }

    public async Task<IEnumerable<Cita>> GetLista()
    {
        return await citasRepositorio.GetLista();
    }

    public async Task<IEnumerable<Abogados>> GetListaA()
    {
        return await citasRepositorio.GetListaA();
    }

    public async Task<IEnumerable<Cliente>> GetListaC()
    {
        return await citasRepositorio.GetListaC();
    }

    public async Task<Cita> GetPorCodigo(string codigo)
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

    public async Task<bool> Nuevo(Cita citas)
    {
        return await citasRepositorio.Nuevo(citas);
    }
}
