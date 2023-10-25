// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemPag.Areas.Identity.Pages.Account
{
    /// <summary>
    ///     Esta API oferece suporte à infraestrutura padrão de interface do usuário do ASP.NET Core Identity
    ///     e não se destina a ser usada diretamente em seu código. Esta API pode ser alterada ou removida em futuras versões.
    /// </summary>
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        /// <summary>
        ///     Manipulador de solicitação HTTP GET para a página de confirmação de redefinição de senha.
        ///     Este método não requer autenticação (AllowAnonymous).
        /// </summary>
        public void OnGet()
        {
            // Este método lida com solicitações HTTP GET para a página.
            // Aqui, geralmente, não é necessário executar nenhuma ação ao carregar a página.
        }
    }
}
