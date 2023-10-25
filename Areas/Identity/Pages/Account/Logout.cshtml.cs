// Desabilita a checagem de nulos no código.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SystemPag.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        // Construtor da classe LogoutModel.
        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // Este método é executado quando o formulário de logout é submetido.
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            // Realiza o logout do usuário.
            await _signInManager.SignOutAsync();

            // Registra uma mensagem de log informando que o usuário fez logout.
            _logger.LogInformation("User logged out.");

            if (returnUrl != null)
            {
                // Se uma URL de redirecionamento estiver especificada, redireciona o usuário para essa URL.
                return LocalRedirect(returnUrl);
            }
            else
            {
                // Se não houver URL de redirecionamento, redireciona o usuário para a página atual.
                // É importante usar um redirecionamento para garantir que a identidade do usuário seja atualizada no navegador.
                return RedirectToPage();
            }
        }
    }
}
