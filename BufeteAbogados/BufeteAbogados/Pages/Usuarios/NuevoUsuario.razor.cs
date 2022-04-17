using BufeteAbogados.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace BufeteAbogados.Pages.Usuarios;

partial class NuevoUsuario
{
    [Inject] private IUsuarioServicio usuarioServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Usuario user = new Usuario();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Clave) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Apellido))
        {
            return;
        }

        Boolean inserto = await usuarioServicio.Nuevo(user);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Usuario creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Usuarios");

    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Usuarios");
    }
}
