// Licenciado para a .NET Foundation sob um ou mais acordos.
// A .NET Foundation licencia este arquivo para você sob a licença MIT.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SystemPag.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    ///     Esta API oferece suporte à infraestrutura padrão de interface do usuário do ASP.NET Core Identity
    ///     e não se destina a ser usada diretamente em seu código. Esta API pode ser alterada ou removida em versões futuras.
    /// </summary>
    public static class ManageNavPages
    {
        // Propriedades estáticas que representam os nomes das páginas do perfil
        public static string Index => "Index";
        public static string Email => "Email";
        public static string ChangePassword => "ChangePassword";
        public static string DownloadPersonalData => "DownloadPersonalData";
        public static string DeletePersonalData => "DeletePersonalData";
        public static string ExternalLogins => "ExternalLogins";
        public static string PersonalData => "PersonalData";
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        // Métodos para definir a classe CSS ativa na navegação com base na página atual
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
        public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData);
        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);
        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        // Método para definir a classe CSS com base na página atual
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
