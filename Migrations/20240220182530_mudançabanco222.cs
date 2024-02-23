using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistenciaTecnicaApi.Migrations
{
    public partial class mudançabanco222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoIdEndereco",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoIdEndereco",
                table: "Clientes",
                column: "EnderecoIdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoIdEndereco",
                table: "Clientes",
                column: "EnderecoIdEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoIdEndereco",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EnderecoIdEndereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EnderecoIdEndereco",
                table: "Clientes");
        }
    }
}
