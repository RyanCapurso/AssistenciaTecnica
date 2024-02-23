using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistenciaTecnicaApi.Migrations
{
    public partial class mudançabanco222222222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Aparelhos",
                newName: "ClienteIdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Aparelhos_IdCliente",
                table: "Aparelhos",
                newName: "IX_Aparelhos_ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Aparelhos_Clientes_ClienteIdCliente",
                table: "Aparelhos",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelhos_Clientes_ClienteIdCliente",
                table: "Aparelhos");

            migrationBuilder.RenameColumn(
                name: "ClienteIdCliente",
                table: "Aparelhos",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Aparelhos_ClienteIdCliente",
                table: "Aparelhos",
                newName: "IX_Aparelhos_IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
