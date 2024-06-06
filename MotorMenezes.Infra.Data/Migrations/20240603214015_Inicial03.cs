using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MotorMenezes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CNHType_CNHTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ItemReservaTermoAceite");

            migrationBuilder.DropTable(
                name: "ItemReserva");

            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "TipoItemReserva");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "AspNetUsers",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<int>(
                name: "CNHTypeId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CNHNumber",
                table: "AspNetUsers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CNHType_CNHTypeId",
                table: "AspNetUsers",
                column: "CNHTypeId",
                principalTable: "CNHType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CNHType_CNHTypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "AspNetUsers",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CNHTypeId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNHNumber",
                table: "AspNetUsers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdentificadorImagem = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoItemReserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoItemReserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemReserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    TipoItemReservaId = table.Column<int>(type: "integer", nullable: false),
                    AprovacaoAutomatica = table.Column<bool>(type: "boolean", nullable: false),
                    Comentario = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Cor = table.Column<string>(type: "text", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HorarioFuncionamentoFim = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HorarioFuncionamentoInicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    LimitadoPorData = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReserva_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemReserva_TipoItemReserva_TipoItemReservaId",
                        column: x => x.TipoItemReservaId,
                        principalTable: "TipoItemReserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemReservaTermoAceite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemReservaId = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFimVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataInicioVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Termo = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReservaTermoAceite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReservaTermoAceite_ItemReserva_ItemReservaId",
                        column: x => x.ItemReservaId,
                        principalTable: "ItemReserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReserva_CondominioId",
                table: "ItemReserva",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReserva_TipoItemReservaId",
                table: "ItemReserva",
                column: "TipoItemReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReservaTermoAceite_ItemReservaId",
                table: "ItemReservaTermoAceite",
                column: "ItemReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CNHType_CNHTypeId",
                table: "AspNetUsers",
                column: "CNHTypeId",
                principalTable: "CNHType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
