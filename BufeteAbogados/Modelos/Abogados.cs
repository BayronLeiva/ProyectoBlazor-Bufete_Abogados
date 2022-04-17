using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Abogados
{
    [Required(ErrorMessage = "El campo Codigo es obligatorio")]
    public string CodigoAbogado { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El campo Apellido es obligatorio")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    public string Telefono { get; set; }
    [Required(ErrorMessage = "El campo Correo es obligatorio")]
    public string Correo { get; set; }
    public bool EstaActivo { get; set; }
}
