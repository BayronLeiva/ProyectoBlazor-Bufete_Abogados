using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos;

public class Citas
{
    public string CodigoCliente { get; set; }
    public string CodigoAbogado { get; set; }
    [Required(ErrorMessage = "El campo Codigo es obligatorio")]
    public string CodigoCita { get; set; }
    [Required(ErrorMessage = "El campo Fecha es obligatorio")]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
    public string Descripcion { get; set; }
}
