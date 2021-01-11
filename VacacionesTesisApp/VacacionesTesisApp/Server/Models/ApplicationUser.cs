﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacacionesTesisApp.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsEnabled { get; set; }
        public string FullNameUser { get; set; }
    }
}
