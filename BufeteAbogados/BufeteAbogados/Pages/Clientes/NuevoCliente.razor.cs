using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Clientes;

partial class NuevoCliente
{
    [Inject] private IClienteServicio clienteServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Cliente cliente = new Cliente();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(cliente.Codigo) || string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido) || string.IsNullOrEmpty(Convert.ToString(cliente.Edad)) || string.IsNullOrEmpty(Convert.ToString(cliente.Telefono)))
        {
            return;
        }

        Boolean inserto = await clienteServicio.Nuevo(cliente);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Cliente creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Cliente no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Clientes");

    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Clientes");
    }
}
