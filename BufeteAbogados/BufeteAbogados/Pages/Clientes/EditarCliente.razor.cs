using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Clientes;

partial class EditarCliente
{
    [Inject] private IClienteServicio _clienteServicio { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
    [Parameter] public string Codigo { get; set; }

    Cliente cliente = new Cliente();

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Codigo))
        {
            cliente = await _clienteServicio.GetPorCodigo(Codigo);
        }
    }

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(cliente.Codigo) || string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido) || string.IsNullOrEmpty(Convert.ToString(cliente.Edad)) || string.IsNullOrEmpty(Convert.ToString(cliente.Telefono)))
        {
            return;
        }

        Boolean edito = await _clienteServicio.Actualizar(cliente);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Cliente actualizado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Cliente no se pudo actualizar", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/Clientes");
    }

    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Clientes");
    }

    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el cliente?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _clienteServicio.Eliminar(cliente);
            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Cliente eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Clientes");
            }
            else
            {
                await Swal.FireAsync("Error", "Cliente no se pudo eliminar", SweetAlertIcon.Error);
            }
        }
    }
}
