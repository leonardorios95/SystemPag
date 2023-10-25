using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SystemPag.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Configura e adiciona o contexto do banco de dados usando a cadeia de conexão "DefaultConnection".

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Configura e adiciona o Identity com o usuário padrão "IdentityUser" e armazena informações no banco de dados.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Adiciona um filtro de exceção para exibir informações de desenvolvedor no ambiente de desenvolvimento.

builder.Services.AddControllersWithViews();
// Adiciona serviços para controladores e visualizações.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    // Em ambiente de desenvolvimento, habilita o ponto de extremidade de migrações para gerenciar o banco de dados.
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // Em ambiente de produção, configura um tratamento de exceção personalizado para redirecionar para a página de erro.

    app.UseHsts();
    // Habilita HSTS (HTTP Strict Transport Security) para melhorar a segurança em produção.
}

app.UseHttpsRedirection();
// Redireciona para HTTPS, se necessário.

app.UseStaticFiles();
// Serve arquivos estáticos, como CSS, JavaScript e imagens.

app.UseRouting();

app.UseAuthentication();
// Habilita a autenticação para identificar os usuários.

app.UseAuthorization();
// Habilita a autorização para controlar o acesso com base em políticas.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Configura a rota padrão para controladores MVC.

app.MapRazorPages();
// Mapeia páginas Razor, caso seja necessário.

app.Run();
// Inicia a aplicação.
