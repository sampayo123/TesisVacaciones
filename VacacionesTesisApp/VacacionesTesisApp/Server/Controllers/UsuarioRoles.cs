using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacacionesTesisApp.Server.Data;
using VacacionesTesisApp.Server.Models;

namespace VacacionesTesisApp.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRoles : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsuarioRoles(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var not = await _context.UserRoles.ToListAsync();
            return Ok(not);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var use = await _context.UserRoles.Where(a => a.RoleId.Equals(id)).ToListAsync();
            return Ok(use);
        }
    }

}
