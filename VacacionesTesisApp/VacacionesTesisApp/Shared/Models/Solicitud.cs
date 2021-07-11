﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VacacionesTesisApp.Shared.Models
{
    public class Solicitud
    {
        public string Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadDias { get; set; }
        [RegularExpression(@"^[a-z+A-Z]+['\s]*$", ErrorMessage = "Este campo solo admite letras")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Estatus { get; set; }
        public Empleado Empleado { get; set; }
        public string EmpleadoId { get; set; }
    }
}
