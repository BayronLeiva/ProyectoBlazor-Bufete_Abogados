using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.PagesAbogados;

partial class PEditarAbogado
{
    [Inject] private IAbogadoServicio _abogadoServicio { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    [Parameter] public string CodigoAbogado { get; set; }

    Abogados abog = new Abogados();

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(CodigoAbogado))
        {
            abog = await _abogadoServicio.GetPorCodigo(CodigoAbogado);
        }
    }

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(abog.CodigoAbogado) || string.IsNullOrEmpty(abog.Nombre) || string.IsNullOrEmpty(abog.Apellido) || string.IsNullOrEmpty(abog.Telefono) || string.IsNullOrEmpty(abog.Correo))
        {
            return;
        }

        Boolean edito = await _abogadoServicio.Actualizar(abog);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Usuario del abogado actualizado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario del abogado no se pudo actualizar", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/PAbogados");
    }

    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/PAbogados");
    }

    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el usuario del abogado?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _abogadoServicio.Eliminar(abog);
            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Usuario del abogado eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/PAbogados");
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario del abogado no se pudo eliminar", SweetAlertIcon.Error);
            }
        }
    }
}
