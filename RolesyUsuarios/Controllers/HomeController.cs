using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RolesyUsuarios.Models;

namespace RolesyUsuarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //NUEVO HAY QUE INSERTAR "SignInManager<IdentityUser> _signInManager      UserManager<IdentityUser> _userManager"
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        //NUEVO HAY QUE INSERTAR "SignInManager<IdentityUser> _signInManager      UserManager<IdentityUser> _userManager"
        public HomeController(ILogger<HomeController> logger,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager)
            
        {
            _logger = logger;
            //NUEVO HAY QUE INSERTAR "SignInManager<IdentityUser> _signInManager      UserManager<IdentityUser> _userManager"
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();


        }
        // ROL ADMINISTRADOR. Tienes que coger el objeto "user" y si es administrador "return View()"
        // El metodo "IsSignedIn(User)" mira si esta registrado ese usuario y si no lo esta "return NotFound()"
        // Si esta registrado se mira el rol "IsInRoleAsync()" y se decide que hacer
        public async Task<IActionResult> Administrador()
        {
            if (_signInManager.IsSignedIn(User))
            {
                AppUser user = await _userManager.GetUserAsync(User);

                if (await _userManager.IsInRoleAsync(user, "Administrador"))
                {
                    return View();
                }
            }
            return NotFound();
        }

        // HASTA AQUI ADMINISTRADOR------------------------------------------------------


        //  Si ejecutas "Privvacy" y estas logeado vas a la "View()". Todos los roles vales no esta acotado a un rol especifico
        public IActionResult Privacy()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
