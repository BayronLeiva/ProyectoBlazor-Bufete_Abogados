using BufeteAbogados.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Clientes;

partial class Clientes
{
    [Inject] private IClienteServicio _clienteServicio { get; set; }

    private IEnumerable<Cliente> clientesLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        clientesLista = await _clienteServicio.GetLista();
    }
}
