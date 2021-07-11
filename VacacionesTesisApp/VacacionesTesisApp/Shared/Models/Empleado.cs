using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VacacionesTesisApp.Shared.Models
{
    public class Empleado
    {
        public string Id { get; set; }
        [RegularExpression(@"^[a-z+A-Z]+['\s]*$", ErrorMessage = "Este campo solo admite letras")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[a-z+A-Z]+['\s]*$", ErrorMessage = "Este campo solo admite letras")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellido { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Este campo solo admite números")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime? FechaIngreso { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Este campo solo admite números")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int DiasDisponibles { get; set; }
        public Cargo Cargo { get; set; }
        public string CargoId { get; set; }
        public string EmailUsuario  { get; set; }
        public string NombreUsuario  { get; set; }
        
    }
}
