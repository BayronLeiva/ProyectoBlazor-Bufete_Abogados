using Modelos;

namespace BufeteAbogados.Interfaces;

public interface ICitasServicio
{
    Task<bool> Nuevo(Cita citas);

    Task<bool> Eliminar(Cita citas);

    Task<IEnumerable<Cita>> GetLista();

    Task<Cita> GetPorCodigo(string codigo);

    Task<Abogados> GetPorCodigoAbogados(string codigo);

    Task<Cliente> GetPorCodigoClientes(string codigo);

    Task<IEnumerable<Cliente>> GetListaC();

    Task<IEnumerable<Abogados>> GetListaA();
}
