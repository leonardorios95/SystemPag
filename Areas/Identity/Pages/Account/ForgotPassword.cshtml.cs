// Define a área de nomes e desabilita a verificação de nulos para este arquivo.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace SystemPag.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // Define a classe de modelo de entrada para o formulário.
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            // Define as propriedades do modelo, como o campo de e-mail.
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        // Manipula a solicitação POST do formulário de redefinição de senha.
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Verifica se o usuário com o email fornecido existe e se o email foi confirmado.
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Não revela se o usuário não existe ou o email não foi confirmado.
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // Gera um token de redefinição de senha.
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                // Codifica o token em um formato seguro para URL.
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                // Cria uma URL para redefinir a senha, incluindo o token.
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                // Envia um email com a URL de redefinição de senha.
                await _emailSender.SendEmailAsync(
                    Input.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                // Redireciona para a página de confirmação de redefinição de senha.
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            // Retorna a página se o modelo não for válido.
            return Page();
        }
    }
}
