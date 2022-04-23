using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio;

public class CitasRepositorio : ICitasRepositorio
{

    private string CadenaConexion;

    public CitasRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    public async Task<bool> Eliminar(Citas citas)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM citas WHERE CodigoCita = @CodigoCita;";
            resultado = await conexion.ExecuteAsync(sql, new { citas.CodigoCita });

            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Citas>> GetLista()
    {
        IEnumerable<Citas> lista = new List<Citas>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM citas;";
            lista = await conexion.QueryAsync<Citas>(sql);
        }
        catch (Exception)
        {
        }
        return lista;
    }

    public async Task<Citas> GetPorCodigo(string codigo)
    {
        Citas cita = new Citas();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM citas WHERE CodigoCita = @CodigoCita;";
            cita = await conexion.QueryFirstAsync<Citas>(sql, new { codigo });
        }
        catch (Exception)
        {
        }
        return cita;
    }

    public async Task<Abogados> GetPorCodigoAbogados(string codigo)
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

    public async Task<Cliente> GetPorCodigoClientes(string codigo)
    {
        Cliente cliente = new Cliente();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM clientes WHERE Codigo = @Codigo;";
            cliente = await conexion.QueryFirstAsync<Cliente>(sql, new { codigo });
        }
        catch (Exception)
        {
        }
        return cliente;
    }

    public async Task<bool> Nuevo(Citas citas)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO citas (CodigoCliente, CodigoAbogado, CodigoCita, Fecha, Descripcion) VALUES(@CodigoCliente, @CodigoAbogado, @CodigoCita, @Fecha, @Descripcion);";
            resultado = await conexion.ExecuteAsync(sql, citas);
            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
