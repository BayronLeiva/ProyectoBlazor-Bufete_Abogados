using Modelos;

namespace Datos.Interfaces;

public interface IClienteRepositorio
{
    Task<bool> Nuevo(Cliente cliente);

    Task<bool> Actualizar(Cliente cliente);

    Task<bool> Eliminar(Cliente cliente);

    Task<IEnumerable<Cliente>> GetLista();

    Task<Cliente> GetPorCodigo(string codigo);
}

