using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.PagesAbogados;

partial class PNuevoAbogado
{
    [Inject] private IAbogadoServicio abogadoServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Abogados abog = new Abogados();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(abog.CodigoAbogado) || string.IsNullOrEmpty(abog.Nombre) || string.IsNullOrEmpty(abog.Apellido) || string.IsNullOrEmpty(abog.Telefono) || string.IsNullOrEmpty(abog.Correo))
        {
            return;
        }

        Boolean inserto = await abogadoServicio.Nuevo(abog);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Usuario del abogado creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario del abogado no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/PAbogados");
    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/PAbogados");
    }
}
