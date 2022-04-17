using Modelos;

namespace Datos.Interfaces
{
    internal interface IAbogadoRepositorio
    {
        Task<bool> Nuevo(Abogados abogado);

        Task<bool> Actualizar(Abogados abogado);

        Task<bool> Eliminar(Abogados abogado);

        Task<IEnumerable<Abogados>> GetLista();

        Task<Abogados> GetPorCodigo(string codigo);
    }
}
