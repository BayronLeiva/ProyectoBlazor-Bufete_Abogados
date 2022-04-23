using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private string CadenaConexion;

    public UsuarioRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    public async Task<bool> Actualizar(Usuario usuario)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE usuarios SET Codigo = @Codigo, Clave = @Clave, Nombre = @Nombre, Apellido = @Apellido, EstaActivo = @EstaActivo WHERE Codigo = @Codigo;";
            resultado = await conexion.ExecuteAsync(sql, new { usuario.Codigo, usuario.Clave, usuario.Nombre, usuario.Apellido, usuario.EstaActivo });

            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> Eliminar(Usuario usuario)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM usuarios WHERE Codigo = @Codigo;";
            resultado = await conexion.ExecuteAsync(sql, new { usuario.Codigo });

            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Usuario>> GetLista()
    {
        IEnumerable<Usuario> lista = new List<Usuario>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM usuarios;";
            lista = await conexion.QueryAsync<Usuario>(sql);
        }
        catch (Exception)
        {
        }
        return lista;
    }

    public async Task<Usuario> GetPorCodigo(string codigo)
    {
        Usuario user = new Usuario();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM usuarios WHERE Codigo = @Codigo;";
            user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigo });
        }
        catch (Exception)
        {
        }
        return user;
    }

    public async Task<bool> Nuevo(Usuario usuario)
    {
        int resultado;

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO usuarios (Codigo, Clave, Nombre, Apellido, EstaActivo) VALUES(@Codigo, @Clave, @Nombre, @Apellido, @EstaActivo);";
            resultado = await conexion.ExecuteAsync(sql, usuario);
            return resultado > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> ValidarUsuario(Login login)
    {
        bool valido = false;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT 1 FROM usuarios WHERE Codigo = Codigo AND Clave = Clave;";
            valido = await conexion.ExecuteScalarAsync<bool>(sql, new { login.Codigo, login.Clave });
        }
        catch (Exception)
        {
        }
        return valido;
    }
}
