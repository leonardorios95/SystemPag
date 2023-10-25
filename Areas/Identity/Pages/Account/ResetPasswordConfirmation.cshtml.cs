#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemPag.Areas.Identity.Pages.Account
{
    /// <summary>
    ///     Esta classe representa a página de confirmação de redefinição de senha.
    ///     Essa página é parte da infraestrutura padrão de interface do usuário do ASP.NET Core Identity
    ///     e não é destinada a ser usada diretamente em seu código. 
    ///     Esta API pode mudar ou ser removida em futuras versões.
    /// </summary>
    [AllowAnonymous]
    public class ResetPasswordConfirmationModel : PageModel
    {
        /// <summary>
        ///     Método chamado quando a página é acessada via HTTP GET.
        /// </summary>
        public void OnGet()
        {
            // Este método não executa nenhuma lógica adicional e a página simplesmente é exibida para informar ao usuário
            // que a redefinição de senha foi concluída com sucesso.
        }
    }
}
