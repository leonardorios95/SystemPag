#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace SystemPag.Areas.Identity.Pages.Account
{
    // Esta classe representa a página de login da aplicação.
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // A propriedade InputModel representa os dados de entrada do usuário na página de login.
        [BindProperty]
        public InputModel Input { get; set; }

        // Esta lista de AuthenticationScheme contém os esquemas de autenticação externa disponíveis.
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        // A propriedade ReturnUrl armazena a URL para a qual o usuário será redirecionado após o login.
        public string ReturnUrl { get; set; }

        // A propriedade ErrorMessage é usada para exibir mensagens de erro na página de login.
        [TempData]
        public string ErrorMessage { get; set; }

        // A classe InputModel contém os campos de entrada do usuário na página de login.
        public class InputModel
        {
            [Required(ErrorMessage = "O CPF é obrigatório")]
            [Display(Name = "CPF")]
            public string Email { get; set; }

            [Required(ErrorMessage = "A Senha é obrigatória")]
            [Display(Name = "Senha")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Manter conectado")]
            public bool RememberMe { get; set; }
        }

        // Este método é executado quando a página de login é acessada (HTTP GET).
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Limpa o cookie de autenticação externa para garantir um processo de login limpo.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // Obtém os esquemas de autenticação externa disponíveis.
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        // Este método é executado quando o formulário de login é enviado (HTTP POST).
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            // Obtém os esquemas de autenticação externa disponíveis.
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // Faz uma tentativa de login com as credenciais fornecidas pelo usuário.
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário logado com sucesso.");
                    return LocalRedirect(returnUrl);
                }

                if (result.RequiresTwoFactor)
                {
                    // Redireciona para a página de autenticação de dois fatores, se necessário.
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Conta de usuário bloqueada.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "CPF ou senha incorretos.");
                    return Page();
                }
            }

            // Se chegarmos até aqui, algo deu errado, retorna ao formulário.
            return Page();
        }
    }
}
