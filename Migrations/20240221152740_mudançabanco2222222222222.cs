using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistenciaTecnicaApi.Migrations
{
    public partial class mudançabanco2222222222222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelhos_Clientes_IdCliente",
                table: "Aparelhos");

            migrationBuilder.DropIndex(
                name: "IX_Aparelhos_IdCliente",
                table: "Aparelhos");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Aparelhos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Aparelhos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aparelhos_IdCliente",
                table: "Aparelhos",
                column: "IdCliente");

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
