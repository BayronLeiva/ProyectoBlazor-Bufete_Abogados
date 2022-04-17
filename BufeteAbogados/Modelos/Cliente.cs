using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Cliente
{
    [Required(ErrorMessage = "El campo Codigo es obligatorio")]
    public string Codigo { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El campo Apellido es obligatorio")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "El campo Edad es obligatorio")]
    public int Edad { get; set; }
    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    public int Telefono { get; set; }
}
