using System;
using System.Collections.Generic;
using System.Text;

namespace VacacionesTesisApp.Shared.Models
{
   public class Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int DiasDisponibles { get; set; }
        public Cargo Cargo { get; set; }
        public string CargoId { get; set; }
    }
}
