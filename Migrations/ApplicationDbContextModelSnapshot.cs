﻿// Esta classe é um instantâneo de modelo de entidade gerado automaticamente pelo Entity Framework Core.
// O instantâneo representa o modelo de dados atual da aplicação e é usado para criar ou atualizar o banco de dados.
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SystemPag.Data;

[DbContext(typeof(ApplicationDbContext))]
partial class ApplicationDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        // Define informações sobre a versão do Entity Framework Core e configurações relacionais.
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.22")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        // Especifica o uso de colunas de identidade para SQL Server.
        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

        // Define o modelo para a tabela "AspNetRoles" (tabela de funções/roles de usuário).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("ConcurrencyStamp")
                .IsConcurrencyToken()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            b.Property<string>("NormalizedName")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            b.HasKey("Id");

            b.HasIndex("NormalizedName")
                .IsUnique()
                .HasDatabaseName("RoleNameIndex")
                .HasFilter("[NormalizedName] IS NOT NULL");

            b.ToTable("AspNetRoles", (string)null);
        });

        // Define o modelo para a tabela "AspNetRoleClaims" (tabela de reivindicações de função de usuário).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("ClaimType")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("ClaimValue")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("RoleId")
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            b.HasKey("Id");

            b.HasIndex("RoleId");

            b.ToTable("AspNetRoleClaims", (string)null);
        });

        // Define o modelo para a tabela "AspNetUsers" (tabela de usuários).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<int>("AccessFailedCount")
                .HasColumnType("int");

            b.Property<string>("ConcurrencyStamp")
                .IsConcurrencyToken()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Email")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            b.Property<bool>("EmailConfirmed")
                .HasColumnType("bit");

            b.Property<bool>("LockoutEnabled")
                .HasColumnType("bit");

            b.Property<DateTimeOffset?>("LockoutEnd")
                .HasColumnType("datetimeoffset");

            b.Property<string>("NormalizedEmail")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            b.Property<string>("NormalizedUserName")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            b.Property<string>("PasswordHash")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("PhoneNumber")
                .HasColumnType("nvarchar(max)");

            b.Property<bool>("PhoneNumberConfirmed")
                .HasColumnType("bit");

            b.Property<string>("SecurityStamp")
                .HasColumnType("nvarchar(max)");

            b.Property<bool>("TwoFactorEnabled")
                .HasColumnType("bit");

            b.Property<string>("UserName")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            b.HasKey("Id");

            b.HasIndex("NormalizedEmail")
                .HasDatabaseName("EmailIndex");

            b.HasIndex("NormalizedUserName")
                .IsUnique()
                .HasDatabaseName("UserNameIndex")
                .HasFilter("[NormalizedUserName] IS NOT NULL");

            b.ToTable("AspNetUsers", (string)null);
        });

        // Define o modelo para a tabela "AspNetUserClaims" (tabela de reivindicações de usuário).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("ClaimType")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("ClaimValue")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("UserId")
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("AspNetUserClaims", (string)null);
        });

        // Define o modelo para a tabela "AspNetUserLogins" (tabela de logins externos de usuário).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
        {
            b.Property<string>("LoginProvider")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("ProviderKey")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("ProviderDisplayName")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("UserId")
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            b.HasKey("LoginProvider", "ProviderKey");

            b.HasIndex("UserId");

            b.ToTable("AspNetUserLogins", (string)null);
        });

        // Define o modelo para a tabela "AspNetUserRoles" (tabela de associação entre usuários e funções).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
        {
            b.Property<string>("UserId")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("RoleId")
                .HasColumnType("nvarchar(450)");

            b.HasKey("UserId", "RoleId");

            b.HasIndex("RoleId");

            b.ToTable("AspNetUserRoles", (string)null);
        });

        // Define o modelo para a tabela "AspNetUserTokens" (tabela de tokens de usuário).
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
        {
            b.Property<string>("UserId")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("LoginProvider")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("Name")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("Value")
                .HasColumnType("nvarchar(max)");

            b.HasKey("UserId", "LoginProvider", "Name");

            b.ToTable("AspNetUserTokens", (string)null);
        });

        // Define o modelo para a tabela "Cargos".
        modelBuilder.Entity("SystemPag.Models.Cargo", b =>
        {
            b.Property<int>("CargoId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"), 1L, 1);

            b.Property<string>("Descricao")
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");

            b.Property<decimal>("SalarioBase")
                .HasColumnType("decimal (10,2)");

            b.HasKey("CargoId");

            b.ToTable("Cargos");
        });

        // Define o modelo para a tabela "Departamentos".
        modelBuilder.Entity("SystemPag.Models.Departamento", b =>
        {
            b.Property<int>("DepartamentoId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentoId"), 1L, 1);

            b.Property<string>("Descricao")
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");

            b.HasKey("DepartamentoId");

            b.ToTable("Departamentos");
        });

        // Define o modelo para a tabela "Empresas".
        modelBuilder.Entity("SystemPag.Models.Empresa", b =>
        {
            b.Property<int>("EmpresaId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpresaId"), 1L, 1);

            b.Property<string>("CNPJ")
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnType("nvarchar(14)");

            b.Property<string>("RazaoSocial")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            b.HasKey("EmpresaId");

            b.ToTable("Empresas");
        });

        // Define o modelo para a tabela "Funcionarios".
        modelBuilder.Entity("SystemPag.Models.Funcionario", b =>
        {
            b.Property<int>("FuncionarioId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"), 1L, 1);

            b.Property<string>("CPF")
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("nvarchar(11)");

            b.Property<int>("CargoId")
                .HasColumnType("int");

            b.Property<int>("DepartamentoId")
                .HasColumnType("int");

            b.Property<string>("Email")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            b.Property<int>("EmpresaId")
                .HasColumnType("int");

            b.Property<string>("Nome")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            b.HasKey("FuncionarioId");

            b.HasIndex("CargoId");
            b.HasIndex("DepartamentoId");
            b.HasIndex("EmpresaId");

            b.ToTable("Funcionarios");
        });

        // Define o modelo para a tabela "Holerites".
        modelBuilder.Entity("SystemPag.Models.Holerite", b =>
        {
            b.Property<int>("HoleriteId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoleriteId"), 1L, 1);

            b.Property<string>("AnoReferencia")
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("nvarchar(4)");

            b.Property<decimal>("DescontoConvenio")
                .HasColumnType("decimal (10,2)");

            b.Property<decimal>("DescontoINSS")
                .HasColumnType("decimal (10,2)");

            b.Property<decimal>("DescontoIRRF")
                .HasColumnType("decimal (10,2)");

            b.Property<decimal>("DescontoVR")
                .HasColumnType("decimal (10,2)");

            b.Property<decimal>("DescontoVT")
                .HasColumnType("decimal (10,2)");

            b.Property<int>("FuncionarioId")
                .HasColumnType("int");

            b.Property<int>("HorasExtras")
                .HasColumnType("int");

            b.Property<int>("MesReferencia")
                .HasColumnType("int");

            b.Property<decimal>("SalarioBruto")
                .HasColumnType("decimal (10,2)");

            b.Property<decimal>("SalarioLiquido")
                .HasColumnType("decimal (10,2)");

            b.Property<int>("TotalFaltas")
                .HasColumnType("int");

            b.HasKey("HoleriteId");

            b.HasIndex("FuncionarioId");

            b.ToTable("Holerites");
        });

        // Define as relações entre as tabelas.
        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
        {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                .WithMany()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
        {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
        {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
        {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                .WithMany()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
        {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("SystemPag.Models.Funcionario", b =>
        {
            // Define a relação entre Funcionario e Cargo, Departamento e Empresa.
            b.HasOne("SystemPag.Models.Cargo", "Cargo")
                .WithMany("Funcionarios")
                .HasForeignKey("CargoId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("SystemPag.Models.Departamento", "Departamento")
                .WithMany("Funcionarios")
                .HasForeignKey("DepartamentoId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("SystemPag.Models.Empresa", "Empresa")
                .WithMany("Funcionarios")
                .HasForeignKey("EmpresaId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Cargo");
            b.Navigation("Departamento");
            b.Navigation("Empresa");
        });

        modelBuilder.Entity("SystemPag.Models.Holerite", b =>
        {
            // Define a relação entre Holerite e Funcionario.
            b.HasOne("SystemPag.Models.Funcionario", "Funcionario")
                .WithMany("Holerites")
                .HasForeignKey("FuncionarioId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Funcionario");
        });

        modelBuilder.Entity("SystemPag.Models.Cargo", b =>
        {
            b.Navigation("Funcionarios");
        });

        modelBuilder.Entity("SystemPag.Models.Departamento", b =>
        {
            b.Navigation("Funcionarios");
        });

        modelBuilder.Entity("SystemPag.Models.Empresa", b =>
        {
            b.Navigation("Funcionarios");
        });

        modelBuilder.Entity("SystemPag.Models.Funcionario", b =>
        {
            b.Navigation("Holerites");
        });
    }
}
