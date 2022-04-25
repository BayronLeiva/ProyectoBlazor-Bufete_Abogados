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

    public async Task<bool> Eliminar(Cita citas)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM citas WHERE CodigoCita = CodigoCita;";
            resultado = await conexion.ExecuteAsync(sql, new { citas.CodigoCita });

            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Cita>> GetLista()
    {
        IEnumerable<Cita> lista = new List<Cita>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM citas;";
            lista = await conexion.QueryAsync<Cita>(sql);
        }
        catch (Exception)
        {
        }
        return lista;
    }

    public async Task<Cita> GetPorCodigo(string codigo)
    {
        Cita cita = new Cita();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM citas WHERE CodigoCita = @CodigoCita;";
            cita = await conexion.QueryFirstAsync<Cita>(sql, new { codigo });
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

    public async Task<bool> Nuevo(Cita citas)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO citas (CodigoCliente, CodigoAbogado, CodigoCita, Fecha, Descripcion) VALUES (@CodigoCliente, @CodigoAbogado, @CodigoCita, @Fecha, @Descripcion);";
            resultado = await conexion.ExecuteAsync(sql, citas);
            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Cliente>> GetListaC()
    {
        IEnumerable<Cliente> lista = new List<Cliente>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM clientes;";
            lista = await conexion.QueryAsync<Cliente>(sql);
        }
        catch (Exception)
        {
        }
        return lista;
    }

    public async Task<IEnumerable<Abogados>> GetListaA()
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
}
