using BufeteAbogados.Data;
using BufeteAbogados.Interfaces;
using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;

namespace BufeteAbogados.Servicios;

public class ClienteServicio : IClienteServicio
{
    private readonly MySqlConfiguration _configuration;
    private IClienteRepositorio clienteRepositorio;

    public ClienteServicio(MySqlConfiguration configuration)
    {
        _configuration = configuration;
        clienteRepositorio = new ClienteRepositorio(configuration.CadenaConexion);
    }
    public async Task<bool> Actualizar(Cliente cliente)
    {
        return await clienteRepositorio.Actualizar(cliente);
    }

    public async Task<bool> Eliminar(Cliente cliente)
    {
        return await clienteRepositorio.Eliminar(cliente);
    }

    public async Task<IEnumerable<Cliente>> GetLista()
    {
        return await clienteRepositorio.GetLista();
    }

    public async Task<Cliente> GetPorCodigo(string codigo)
    {
        return await clienteRepositorio.GetPorCodigo(codigo);
    }

    public async Task<bool> Nuevo(Cliente cliente)
    {
        return await clienteRepositorio.Nuevo(cliente);
    }
}
