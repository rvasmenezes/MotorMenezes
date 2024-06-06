using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorMenezes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNHImageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "PossuiImagem",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossuiImagem",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "CNHImageId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);
        }
    }
}
