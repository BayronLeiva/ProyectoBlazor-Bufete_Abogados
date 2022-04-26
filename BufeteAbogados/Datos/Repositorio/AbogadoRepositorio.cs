using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio;

public class AbogadoRepositorio : IAbogadoRepositorio
{

    private string CadenaConexion;

    public AbogadoRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    public async Task<bool> Actualizar(Abogados abogado)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE abogados SET CodigoAbogado = @CodigoAbogado, Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Correo = @Correo, EstaActivo = @EstaActivo WHERE CodigoAbogado = @CodigoAbogado;";
            resultado = await conexion.ExecuteAsync(sql, new { abogado.CodigoAbogado, abogado.Nombre, abogado.Apellido, abogado.Telefono, abogado.Correo, abogado.EstaActivo });

            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> Eliminar(Abogados abogado)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM abogados WHERE CodigoAbogado = @CodigoAbogado;";
            resultado = await conexion.ExecuteAsync(sql, new { abogado.CodigoAbogado });

            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Abogados>> GetLista()
    {
        IEnumerable<Abogados> lista = new List<Abogados>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM abogados;";
            lista = await conexion.QueryAsync<Abogados>(sql);
        }
        catch (Exception)
        {
        }
        return lista;
    }

    public async Task<Abogados> GetPorCodigo(string codigo)
    {
        Abogados abog = new Abogados();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM abogados WHERE CodigoAbogado = CodigoAbogado;";
            abog = await conexion.QueryFirstAsync<Abogados>(sql, new { codigo });
        }
        catch (Exception)
        {
        }
        return abog;
    }

    public async Task<bool> Nuevo(Abogados abogado)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO abogados (CodigoAbogado, Nombre, Apellido, Telefono, Correo, EstaActivo) VALUES (@CodigoAbogado, @Nombre, @Apellido, @Telefono, @Correo, @EstaActivo);";
            resultado = await conexion.ExecuteAsync(sql, abogado);
            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
