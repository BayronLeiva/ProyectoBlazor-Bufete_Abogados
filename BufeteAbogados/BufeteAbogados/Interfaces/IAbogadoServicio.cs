using Modelos;

namespace BufeteAbogados.Interfaces;

public interface IAbogadoServicio
{
    Task<bool> Nuevo(Abogados abogado);

    Task<bool> Actualizar(Abogados abogado);

    Task<bool> Eliminar(Abogados abogado);

    Task<IEnumerable<Abogados>> GetLista();

    Task<Abogados> GetPorCodigo(string codigo);
}
