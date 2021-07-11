using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VacacionesTesisApp.Shared.Models
{
    public class Cargo
    {
        public string Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(5)]
        public string Descripcion { get; set; }
    }
}
