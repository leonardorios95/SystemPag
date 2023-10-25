using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SystemPag.Models;

namespace SystemPag.Data
{
    // A classe `ApplicationDbContext` herda da classe `IdentityDbContext<IdentityUser>`, que fornece funcionalidades para a autenticação e autorização de usuários.
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        // O construtor recebe opções de contexto do banco de dados através do parâmetro `options`.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // O construtor da classe base é chamado, passando as opções recebidas.
        }

        // As propriedades a seguir representam as tabelas do banco de dados.
        public DbSet<Empresa> Empresa { get; set; }           // Tabela para armazenar informações sobre empresas.
        public DbSet<Departamento> Departamento { get; set; } // Tabela para armazenar informações sobre departamentos.
        public DbSet<Cargo> Cargo { get; set; }               // Tabela para armazenar informações sobre cargos.
        public DbSet<Funcionario> Funcionario { get; set; }   // Tabela para armazenar informações sobre funcionários.
        public DbSet<Holerite> Holerite { get; set; }         // Tabela para armazenar informações sobre holerites.
    }
}
