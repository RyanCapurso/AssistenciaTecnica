using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistenciaTecnicaApi.Migrations
{
    public partial class mudançabanco222222222222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos");

            migrationBuilder.AddForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos");

            migrationBuilder.AddForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
