using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VacacionesTesisApp.Shared.Models;
using VacacionesTesisApp.Server.Data;
using VacacionesTesisApp.Server.Models;
using System.Security.Claims;

namespace VacacionesTesisApp.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   /* [Authorize]*/
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

        public UsuariosController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
           // RoleManager<IdentityRole> roleManager,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
        {
            this.context = context;
            this.userManager = userManager;
//this.roleManager = roleManager;
            this._claimsFactory = claimsFactory;
        }


        //[HttpGet]
        //public async Task<ActionResult<List<UsuarioModel>>> GetUsuarios()
        //{
        //    return await context.Users
        //        .Select(x => new UsuarioModel { Email = x.Email, UserId = x.Id }).ToListAsync();
        //}



        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Usuarios = await context.Users
                .Select(x => new UsuarioModel
                {
                    Nombre = x.FullNameUser,
                    Email = x.Email,
                    UserId = x.Id
                }).ToListAsync();


            var usersRoles = await context.UserRoles.ToListAsync();
            var roles = await context.Roles.ToListAsync();


            foreach (var Item in Usuarios)
            {
                var userRol = usersRoles.Find(x => x.UserId.Equals(Item.UserId));
                if (userRol == null)
                {
                    Item.Rol = "Sin Rol";
                }
                else
                {
                    Item.Rol = roles.Find(x => x.Id.Equals(userRol.RoleId)).Name;
                }


            }

            return Ok(Usuarios);
        }




        [HttpGet("roles")]
        public async Task<ActionResult<List<RolModel>>> GetRoles()
        {
            return await context.Roles
                .Select(x => new RolModel { Nombre = x.Name, RoleId = x.Id }).ToListAsync();
        }


        [HttpGet("rol")]
        public async Task<ActionResult> GetRoles2()
        {
            var roles = await context.Roles
                .Select(x => new RolModel { Nombre = x.Name, RoleId = x.Id }).ToListAsync();
            return Ok(roles);
        }



        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuario(string id)
        {
            var Response = await context.Users.FindAsync(id);

            var usersRoles = await context.UserRoles.ToListAsync();

            var userRol = usersRoles.Find(x => x.UserId.Equals(id));

            var rolName = "Sin Rol";

            if (userRol != null)
            {
                var Role = await context.Roles.FindAsync(userRol.RoleId);
                rolName = Role.Name;
            }

            UsuarioModel usuario = new UsuarioModel()
            {
                UserId = Response.Id,
                Nombre = Response.FullNameUser,
                Email = Response.Email,
                Rol = rolName
            };

            if (Response == null)
            {
                return NotFound();
            }

            return usuario;
        }




        [HttpPost("asignarRol")]
        public async Task<ActionResult> AsignarRolUsuario(EditarRolModel editarRolModel)
        {
            var usuario = await userManager.FindByIdAsync(editarRolModel.UserId);
            await userManager.AddToRoleAsync(usuario, editarRolModel.RoleId);
            return NoContent();
        }

        [HttpPost("removerRol")]
        public async Task<ActionResult> RemoverUsuarioRol(EditarRolModel editarRolModel)
        {
            var usuario = await userManager.FindByIdAsync(editarRolModel.UserId);
            await userManager.RemoveFromRoleAsync(usuario, editarRolModel.RoleId);
            return NoContent();
        }


        [HttpPost("crearRol")]
        public async Task<ActionResult> CrearRol(RolModel Rol)
        {
            var guid = Guid.NewGuid();
            Rol.RoleId = guid.ToString();

            var usuario = await roleManager.FindByIdAsync(Rol.Nombre);
            IdentityRole Role = new IdentityRole { Id = Rol.RoleId, Name = Rol.Nombre, NormalizedName = Rol.NombreNormalizado };
            await roleManager.CreateAsync(Role);
            return NoContent();
        }



        [HttpPost("editarUsuario")]
        public async Task<ActionResult> EditarUsuario(UsuarioModel usuario)
        {

            // First get the user, in this example, by ID but also you can use FindByEmailAsync()
            var identityUser = await userManager.FindByIdAsync(usuario.UserId);
            // Change the Username field            
            await userManager.SetUserNameAsync(identityUser, usuario.Nombre);
            // Change the email field
            await userManager.SetEmailAsync(identityUser, usuario.Email);


            var principal = await _claimsFactory.CreateAsync(identityUser);

            var claims = principal.Claims.ToList();
            claims.Add(new Claim("NombreCompleto", usuario.Nombre ?? usuario.Nombre));

            //context.IssuedClaims = claims;




            return NoContent();
        }




        //[HttpPost("CrearRol")]
        //public async Task<ActionResult> CrearRol(RolModel Rol)
        //{
        //    var RolExiste = await roleManager.RoleExistsAsync(Rol.Nombre);

        //    if (RolExiste){
        //        IdentityRole Role = new IdentityRole { Id = Rol.RoleId, Name = Rol.Nombre, NormalizedName = Rol.NombreNormalizado };
        //        var Response = await roleManager.CreateAsync(Role);
        //        return Ok(Role);
        //    }

        //    return Conflict();
        //}




        /*public class UsuariosController : Controller
        {


            public IActionResult Index()
            {
                return View();
            }
        }*/
    }
}