using Modelos;

namespace BufeteAbogados.Interfaces;

public interface ICitasServicio
{
    Task<bool> Nuevo(Citas citas);

    Task<bool> Eliminar(Citas citas);

    Task<IEnumerable<Citas>> GetLista();

    Task<Citas> GetPorCodigo(string codigo);

    Task<Abogados> GetPorCodigoAbogados(string codigo);

    Task<Cliente> GetPorCodigoClientes(string codigo);
}
