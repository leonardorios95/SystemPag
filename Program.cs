using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SystemPag.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Configura e adiciona o contexto do banco de dados usando a cadeia de conex�o "DefaultConnection".

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Configura e adiciona o Identity com o usu�rio padr�o "IdentityUser" e armazena informa��es no banco de dados.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Adiciona um filtro de exce��o para exibir informa��es de desenvolvedor no ambiente de desenvolvimento.

builder.Services.AddControllersWithViews();
// Adiciona servi�os para controladores e visualiza��es.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    // Em ambiente de desenvolvimento, habilita o ponto de extremidade de migra��es para gerenciar o banco de dados.
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // Em ambiente de produ��o, configura um tratamento de exce��o personalizado para redirecionar para a p�gina de erro.

    app.UseHsts();
    // Habilita HSTS (HTTP Strict Transport Security) para melhorar a seguran�a em produ��o.
}

app.UseHttpsRedirection();
// Redireciona para HTTPS, se necess�rio.

app.UseStaticFiles();
// Serve arquivos est�ticos, como CSS, JavaScript e imagens.

app.UseRouting();

app.UseAuthentication();
// Habilita a autentica��o para identificar os usu�rios.

app.UseAuthorization();
// Habilita a autoriza��o para controlar o acesso com base em pol�ticas.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Configura a rota padr�o para controladores MVC.

app.MapRazorPages();
// Mapeia p�ginas Razor, caso seja necess�rio.

app.Run();
// Inicia a aplica��o.
