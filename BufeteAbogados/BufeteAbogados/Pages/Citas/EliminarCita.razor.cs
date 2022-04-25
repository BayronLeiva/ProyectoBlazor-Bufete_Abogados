using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Citas;

partial class EliminarCita
{
    [Inject] private ICitasServicio _citasServicio { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
    Cita cit = new Cita();

    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar los registros?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _citasServicio.Eliminar(cit);
            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Registros eliminados con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Citas");
            }
            else
            {
                await Swal.FireAsync("Error", "Los registros no fueron eliminados", SweetAlertIcon.Error);
            }
        }
    }

    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Citas");
    }
}
