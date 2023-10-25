using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemPag.Migrations
{
    // A classe `Inical` é uma classe de migração gerada automaticamente pelo Entity Framework Core.
    public partial class Inical : Migration
    {
        // O método `Up` é responsável por definir as operações que serão executadas ao aplicar a migração.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Aqui, estamos criando várias tabelas no banco de dados usando o objeto `migrationBuilder`.
            // Cada chamada ao método `CreateTable` define a estrutura de uma tabela.

            // Exemplo de criação de tabela para "AspNetRoles" (tabela de funções/roles de usuário).
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    // ... outras colunas ...
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            // Exemplo de criação de tabela para "AspNetUsers" (tabela de usuários).
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    // ... outras colunas ...
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            // O método `CreateTable` é chamado para cada tabela que desejamos criar.

            // A migração também define índices (por exemplo, "EmailIndex") e chaves estrangeiras (por exemplo, "FK_Funcionarios_CargoId") usando o método `CreateIndex`.

            // O método `Down` é responsável por definir as operações de desfazer (rollback) que seriam executadas ao reverter a migração.

            // Por padrão, o Entity Framework Core gera automaticamente as migrações com base nas alterações no modelo de dados do aplicativo.

            // Essas migrações são usadas para criar ou atualizar o esquema do banco de dados conforme o aplicativo evolui.

            // O Entity Framework Core cuida das operações de banco de dados necessárias para manter o esquema em sincronia com o modelo de dados do aplicativo.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // O método `Down` descreve as operações de desfazer a migração, que geralmente envolvem a remoção das tabelas criadas no método `Up`.

            // Aqui, estamos chamando o método `DropTable` para cada tabela criada no método `Up` a fim de removê-las.

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");
            migrationBuilder.DropTable(
                name: "AspNetUserLogins");
            migrationBuilder.DropTable(
                name: "AspNetUserRoles");
            migrationBuilder.DropTable(
                name: "AspNetUserTokens");
            migrationBuilder.DropTable(
                name: "Holerites");
            migrationBuilder.DropTable(
                name: "AspNetRoles");
            migrationBuilder.DropTable(
                name: "AspNetUsers");
            migrationBuilder.DropTable(
                name: "Funcionarios");
            migrationBuilder.DropTable(
                name: "Cargos");
            migrationBuilder.DropTable(
                name: "Departamentos");
            migrationBuilder.DropTable(
                name: "Empresas");

            // Esse método desfaz as alterações da migração, retornando o banco de dados ao seu estado anterior à aplicação da migração.
        }
    }
}
