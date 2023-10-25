// O cabeçalho de licença e a diretiva "#nullable disable" são fornecidos por padrão.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace SystemPag.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager)
        {
            // Inicializa o modelo ConfirmEmail com um gerenciador de usuário (UserManager).
            _userManager = userManager;
        }

        /// <summary>
        ///     Esta API oferece suporte à infraestrutura de interface de usuário padrão do ASP.NET Core Identity
        ///     e não deve ser usada diretamente no código. Essa API pode mudar ou ser removida em lançamentos futuros.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        // Este método é executado quando a página é acessada com o método GET.
        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            // Verifica se o userId e o código são nulos e redireciona para a página inicial se forem.
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            // Carrega o usuário com base no userId.
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            // Decodifica o código (geralmente um token) que foi codificado em Base64Url.
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            // Confirma o email do usuário usando o código fornecido.
            var result = await _userManager.ConfirmEmailAsync(user, code);

            // Define uma mensagem de status com base no resultado da confirmação.
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";

            return Page();
        }
    }
}
