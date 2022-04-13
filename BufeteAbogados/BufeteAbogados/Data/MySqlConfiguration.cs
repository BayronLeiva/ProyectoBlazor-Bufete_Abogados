namespace BufeteAbogados.Data;

public class MySqlConfiguration
{
    public string CadenaConexion { get; }

    public MySqlConfiguration(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }
}
