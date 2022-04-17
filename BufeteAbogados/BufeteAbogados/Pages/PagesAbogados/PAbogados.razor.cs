using BufeteAbogados.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.PagesAbogados;

partial class PAbogados
{
    [Inject] private IAbogadoServicio _abogadoServicio { get; set; }

    private IEnumerable<Abogados> abogadosLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        abogadosLista = await _abogadoServicio.GetLista();
    }
}