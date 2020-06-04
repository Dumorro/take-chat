using Microsoft.AspNetCore.Mvc;
using Take.BatePapo.Aplicacao.Servicos;

namespace Take.BatePapo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConsultaDeUsuariosDaSalaDeBatePapo _consultaDeUsuariosDaSala;
        public HomeController(IConsultaDeUsuariosDaSalaDeBatePapo consultaDeUsuariosDaSala)
        {
            _consultaDeUsuariosDaSala = consultaDeUsuariosDaSala;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("InicioUsuario");
        }

        [HttpPost]
        public IActionResult Index(string apelido)
        {
            ViewData["UsuarioExistente"] = false;
            var usuarioExistente = _consultaDeUsuariosDaSala.VerificarUsuarioExistente(apelido);
            if (usuarioExistente)
            {
                ViewData["UsuarioExistente"] = usuarioExistente;
                return View("InicioUsuario");
            }
            else
            {
                return View("Index", apelido);
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
