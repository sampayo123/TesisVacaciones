using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VacacionesTesisApp.Client.Helpers
{
    public static class IJSExtensions
    {
        public static async Task<object> MostrarMensaje(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<object>("Swal.fire", mensaje);
        }
        public static async Task<object> MostrarMensaje(this IJSRuntime js, string titulo,
            string mensaje, TipoMensajeSweetAler tipoMensajeSweetAler)
        {
            return await js.InvokeAsync<object>("Swal.fire", titulo, mensaje,
                tipoMensajeSweetAler.ToString());
        }


        //Confirmar eliminar
        public async static Task<bool> Confirm(this IJSRuntime js, string titulo,
            string mensaje, TipoMensajeSweetAler tipoMensajeSweetAler)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mensaje,
                tipoMensajeSweetAler.ToString());
        }


        //Confirmar creación  
        public async static Task<bool> ConfirmCreate(this IJSRuntime js, string titulo,
            string mensaje, TipoMensajeSweetAler tipoMensajeSweetAler)
        {
            return await js.InvokeAsync<bool>("CustomConfirmCreate", titulo, mensaje,
                tipoMensajeSweetAler.ToString());
        }

        //Confirmar creación  sin alerta  despues de la confirmación
        public async static Task<bool> ConfirmCreateSinAlerta(this IJSRuntime js, string titulo,
            string mensaje, TipoMensajeSweetAler tipoMensajeSweetAler)
        {
            return await js.InvokeAsync<bool>("CustomConfirmCreate2", titulo, mensaje,
                tipoMensajeSweetAler.ToString());
        }



        //Confirmar modificar
        public async static Task<bool> ConfirmUpdate(this IJSRuntime js, string titulo,
            string mensaje, TipoMensajeSweetAler tipoMensajeSweetAler)
        {
            return await js.InvokeAsync<bool>("CustomConfirmUpdate", titulo, mensaje,
                tipoMensajeSweetAler.ToString());
        }
    }

    public enum TipoMensajeSweetAler
    {
        question, warning, error, success, info, loading
    }
}

