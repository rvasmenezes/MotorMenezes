using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorMenezes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CNHNumber",
                table: "AspNetUsers",
                column: "CNHNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CNPJ",
                table: "AspNetUsers",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CNHNumber",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CNPJ",
                table: "AspNetUsers");
        }
    }
}
