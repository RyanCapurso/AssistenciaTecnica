using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistenciaTecnicaApi.Migrations
{
    public partial class mudançabanco2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_IdCliente",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Clientes");

            migrationBuilder.CreateTable(
                name: "ClientesEnderecos",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesEnderecos", x => new { x.IdCliente, x.IdEndereco });
                    table.ForeignKey(
                        name: "FK_ClientesEnderecos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesEnderecos_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesEnderecos_IdEndereco",
                table: "ClientesEnderecos",
                column: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesEnderecos");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos",
                column: "IdCliente",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_IdCliente",
                table: "Enderecos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
