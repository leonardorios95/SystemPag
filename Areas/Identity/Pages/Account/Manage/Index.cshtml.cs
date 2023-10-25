// Licenciado para a .NET Foundation sob um ou mais acordos.
// A .NET Foundation licencia este arquivo para você sob a licença MIT.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemPag.Areas.Identity.Pages.Account.Manage
{
    // Classe IndexModel para a página de perfil
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        // Construtor da classe
        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Propriedade para armazenar o nome de usuário (email)
        [Display(Name = "Email")]
        public string Username { get; set; }

        // Propriedades para o nome, CPF, empresa e CNPJ do usuário
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; } = "Leonardo Rios";

        [Required]
        [Display(Name = "CPF")]
        public string CPF { get; } = "40919628826";

        [Required]
        [Display(Name = "Empresa")]
        public string Company { get; } = "Drogaria São Paulo";

        [Required]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; } = "61542110011275";

        [TempData]
        public string StatusMessage { get; set; }

        // Classe InputModel para as entradas do formulário
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Celular")]
            public string PhoneNumber { get; set; }
        }

        // Método para carregar os dados do usuário
        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        // Método chamado quando a página é acessada via GET
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        // Método chamado quando o formulário é submetido via POST
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
            {
                return NotFound($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erro inesperado ao tentar atualizar o celular.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Seu perfil foi atualizado";
            return RedirectToPage();
        }
    }
}
