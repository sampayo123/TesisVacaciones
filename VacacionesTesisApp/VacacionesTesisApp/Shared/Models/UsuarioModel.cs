﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VacacionesTesisApp.Shared.Models
{
    public class UsuarioModel
    {
        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

       [NotMapped]
        public string Rol { get; set; }

        [NotMapped]
        public bool Habilitado { get; set; }
    }
}
