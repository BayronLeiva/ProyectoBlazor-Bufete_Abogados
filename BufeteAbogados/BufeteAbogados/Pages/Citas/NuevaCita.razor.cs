using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Citas;

partial class NuevaCita
{
    [Inject] private ICitasServicio _citasServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Cita cit = new Cita();

    [Inject] private IClienteServicio _clienteServicio { get; set; }

    private IEnumerable<Cliente> clientesLista { get; set; }

    [Inject] private IAbogadoServicio _abogadoServicio { get; set; }

    private IEnumerable<Abogados> abogadosLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        clientesLista = await _clienteServicio.GetLista();

        abogadosLista = await _abogadoServicio.GetLista();
    }



    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(cit.CodigoCliente) || string.IsNullOrEmpty(cit.CodigoAbogado) || string.IsNullOrEmpty(cit.CodigoCita) || string.IsNullOrEmpty(cit.Descripcion) || cit.Fecha == null)
        {
            return;
        }

        Boolean inserto = await _citasServicio.Nuevo(cit);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Cita registrada con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("ERROR", "La cita no se pudo registrar", SweetAlertIcon.Error);
            await Swal.FireAsync("RECUERDA", "Los campos de abogados y clientes deben coincidir con los registros en la aplicación", SweetAlertIcon.Error);
            await Swal.FireAsync("IMPORTANTE", "Recuerda no ingresar un código repetido para una nueva cita", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Citas");
    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Citas");
    }

}
