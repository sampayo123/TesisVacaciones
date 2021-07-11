using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VacacionesTesisApp.Shared.Models
{
    public class EditarRolModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        [NotMapped]
        public string RoleNuevoId { get; set; }
    }
}
