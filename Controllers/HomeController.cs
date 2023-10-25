using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SystemPag.Models;

namespace SystemPag.Controllers
{
    // Atributo [Authorize] indica que este controlador requer autenticação para acessar suas ações.
    [Authorize]
    public class HomeController : Controller
    {
        // Esta ação responde à solicitação GET para a página inicial.
        public IActionResult Index()
        {
            // Retorna uma visualização, geralmente usada para exibir a página inicial.
            return View();
        }

        // Esta ação lida com erros não tratados no aplicativo.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Retorna uma visualização de erro e passa informações sobre o erro para a visualização.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
