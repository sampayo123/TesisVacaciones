﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using VacacionesTesisApp.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using VacacionesTesisApp.Shared.Models;
using VacacionesTesisApp.Server.Data;
using System.Globalization;

namespace VacacionesTesisApp.Server.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        //public static Dictionary<string, HttpClient> HttpClients { get; set; }
        //  public HttpClient client = new HttpClient();

        public RegisterModel(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public bool error  { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required(ErrorMessage = "El campo Nombre es Obligatorio")]
            [Display(Name = "Nombre y apellido")]
            [StringLength(60, ErrorMessage = "Permitido máximo 60 carateres")]
            public string FullNameImput { get; set; }

            [Required(ErrorMessage = "El correo es requerido")]
            [EmailAddress]
            [Display(Name = "Correo")]
            public string Email { get; set; }

            [Required(ErrorMessage = "la contraseña es requerida")]
            [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "El correo es requerido")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Clave")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
/*
        static async Task<UsuarioModel> GetProductAsync(string id)
        {
            UsuarioModel user = null;
            HttpResponseMessage response = await client.GetAsync(id);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.rea<UsuarioModel>();
            }
            return user;
        }*/


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {



            /*  product = await GetProductAsync(url.PathAndQuery);
              ShowProduct(product);*/
            //returnUrl = returnUrl ?? Url.Content("/usuarios");
            bool existe = _context.Users.Any(x => x.Email == Input.Email);
            if (!existe)
            {

            returnUrl = ("/usuarios"); 
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FullNameUser = Input.FullNameImput };
               // var user = new ApplicationUser { UserName = "Admin", Email = "is@mail.com", FullNameUser = "Administrador" };
                var result = await _userManager.CreateAsync(user, Input.Password);
               // var result = await _userManager.CreateAsync(user, "Control6*");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                 }
            }

            // If we got this far, something failed, redisplay form
            return Page();

            }
            else
            {
                if (ModelState.IsValid)
                {
                    error = true;
                }



                return Page();

            }
        }

    }
}
