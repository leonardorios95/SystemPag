// Licenciado para a .NET Foundation sob um ou mais acordos.
// A .NET Foundation licencia este arquivo para você sob a licença MIT.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SystemPag.Areas.Identity.Pages.Account.Manage
{
    // Classe ChangePasswordModel para a página de alteração de senha
    public class ChangePasswordModel : PageModel
    {
        // Injeção de dependências do UserManager, SignInManager e ILogger
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // Classe InputModel para as entradas do formulário
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        // Classe InputModel para as entradas do formulário
        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Senha atual")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nova Senha")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a nova senha")]
            [Compare("NewPassword", ErrorMessage = "As senhas não conferem.")]
            public string ConfirmPassword { get; set; }
        }

        // Método chamado quando a página é acessada via GET
        public async Task<IActionResult> OnGetAsync()
        {
            // Obtém o usuário atual
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            // Verifica se o usuário já possui uma senha
            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        // Método chamado quando o formulário é submetido via POST
        public async Task<IActionResult> OnPostAsync()
        {
            // Verifica a validade do modelo
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Obtém o usuário atual
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            // Tenta alterar a senha do usuário
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            // Atualiza o status de login do usuário
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Usuário alterou a senha com sucesso.");
            StatusMessage = "Senha alterada com sucesso";

            return RedirectToPage();
        }
    }
}
