using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Citas;

partial class Citas
{
    [Inject] private ICitasServicio _citasServicio { get; set; }

    private IEnumerable<Cita> citaLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        citaLista = await _citasServicio.GetLista();
    }

}
