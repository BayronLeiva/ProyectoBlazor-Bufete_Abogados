using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private string CadenaConexion;

        public ClienteRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Cliente cliente)
        {
            int resultado;

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "UPDATE clientes SET Codigo = @Codigo, Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad, Telefono = @Telefono WHERE Codigo = @Codigo;";
                resultado = await conexion.ExecuteAsync(sql, new { cliente.Codigo, cliente.Nombre, cliente.Apellido, cliente.Edad, cliente.Telefono });

                return resultado > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            int resultado;

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "DELETE FROM clientes WHERE Codigo = @Codigo;";
                resultado = await conexion.ExecuteAsync(sql, new { cliente.Codigo });

                return resultado > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Cliente>> GetLista()
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

        public async Task<Cliente> GetPorCodigo(string codigo)
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

        public async Task<bool> Nuevo(Cliente cliente)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "INSERT INTO clientes (Codigo, Nombre, Apellido, Edad, Telefono) VALUES(@Codigo, @Nombre, @Apellido, @Edad, @Telefono);";
                resultado = await conexion.ExecuteAsync(sql, cliente);
                return resultado > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
