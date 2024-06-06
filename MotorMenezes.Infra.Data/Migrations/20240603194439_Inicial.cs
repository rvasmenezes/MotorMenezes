using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MotorMenezes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CNHType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Desctiption = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNHType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdentificadorImagem = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Identificador = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaEntrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoArquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArquivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEncomenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEncomenda", x => x.Id);
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
                name: "TipoMorador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMorador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOcorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOcorrencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CNHImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CNHNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    CNHTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CNHType_CNHTypeId",
                        column: x => x.CNHTypeId,
                        principalTable: "CNHType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aviso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdentificadorImagem = table.Column<Guid>(type: "uuid", nullable: true),
                    OrdemPrioridade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviso_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bloco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloco_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemReserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TipoItemReservaId = table.Column<int>(type: "integer", nullable: false),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    LimitadoPorData = table.Column<bool>(type: "boolean", nullable: false),
                    AprovacaoAutomatica = table.Column<bool>(type: "boolean", nullable: false),
                    Cor = table.Column<string>(type: "text", nullable: true),
                    HorarioFuncionamentoInicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HorarioFuncionamentoFim = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Comentario = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    TipoOcorrenciaId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescricaoOcorrencia = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NameArquivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Extensao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataResolucao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Resolvido = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioResolucaoId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DescricaoResolucao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AspNetUsers_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_TipoOcorrencia_TipoOcorrenciaId",
                        column: x => x.TipoOcorrenciaId,
                        principalTable: "TipoOcorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reuniao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Ata = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Pauta = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Privada = table.Column<bool>(type: "boolean", nullable: false),
                    Link = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataReuniao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataLimiteCheckin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataEncerramento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CodigoExterno = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CondominioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reuniao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reuniao_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reuniao_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCondominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCondominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioCondominio_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCondominio_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCondominio_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Titulo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Identificador = table.Column<Guid>(type: "uuid", nullable: true),
                    Whatsapp = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Facebook = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    Linkedin = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    Instagram = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    Tiktok = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    Youtube = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioServico_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Apartamento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    BlocoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioMoradorId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FracaoIdeal = table.Column<float>(type: "real", nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidade_AspNetUsers_UsuarioMoradorId",
                        column: x => x.UsuarioMoradorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unidade_Bloco_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "Bloco",
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
                    Termo = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataInicioVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFimVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AnexoReuniao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReuniaoId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NameArquivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtensaoArquivo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DataUpload = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoReuniao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnexoReuniao_Reuniao_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reuniao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enquete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Comentario = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    QuantidadeOpcoesPorVoto = table.Column<int>(type: "integer", nullable: false),
                    ReuniaoId = table.Column<int>(type: "integer", nullable: false),
                    TipoVotacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enquete_Reuniao_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reuniao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCheckin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataConfirmacaoPresenca = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReuniaoId = table.Column<int>(type: "integer", nullable: false),
                    Bloco = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Apartamento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presenca_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Reuniao_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reuniao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReuniaoArquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReuniaoId = table.Column<int>(type: "integer", nullable: false),
                    NameArquivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Extensao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    DataUpload = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReuniaoArquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReuniaoArquivo_Reuniao_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reuniao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondominioArquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    TipoArquivoId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NameArquivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Extensao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Identificador = table.Column<Guid>(type: "uuid", nullable: false),
                    DataUpload = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BlocoId = table.Column<int>(type: "integer", nullable: true),
                    UnidadeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominioArquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CondominioArquivo_Bloco_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "Bloco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CondominioArquivo_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondominioArquivo_TipoArquivo_TipoArquivoId",
                        column: x => x.TipoArquivoId,
                        principalTable: "TipoArquivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondominioArquivo_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnidadeId = table.Column<int>(type: "integer", nullable: false),
                    Entregador = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DescricaoProduto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UsuarioMoradorId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UsuarioRetiradaId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TipoEncomendaId = table.Column<int>(type: "integer", nullable: true),
                    DataConfirmacaoMorador = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmpresaEntregaId = table.Column<int>(type: "integer", nullable: true),
                    Tamanho = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Cor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IdentificadorImagemAssinatura = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrega_AspNetUsers_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_AspNetUsers_UsuarioMoradorId",
                        column: x => x.UsuarioMoradorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entrega_AspNetUsers_UsuarioRetiradaId",
                        column: x => x.UsuarioRetiradaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entrega_EmpresaEntrega_EmpresaEntregaId",
                        column: x => x.EmpresaEntregaId,
                        principalTable: "EmpresaEntrega",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entrega_TipoEncomenda_TipoEncomendaId",
                        column: x => x.TipoEncomendaId,
                        principalTable: "TipoEncomenda",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entrega_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioUnidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UnidadeId = table.Column<int>(type: "integer", nullable: false),
                    TipoMoradorId = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataDesvinculacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioUnidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioUnidade_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioUnidade_TipoMorador_TipoMoradorId",
                        column: x => x.TipoMoradorId,
                        principalTable: "TipoMorador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioUnidade_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Placa = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    MarcaModelo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CorId = table.Column<int>(type: "integer", nullable: true),
                    TipoVeiculoId = table.Column<int>(type: "integer", nullable: true),
                    UnidadeId = table.Column<int>(type: "integer", nullable: true),
                    Visitante = table.Column<bool>(type: "boolean", nullable: false),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculo_Cor_CorId",
                        column: x => x.CorId,
                        principalTable: "Cor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Veiculo_TipoVeiculo_TipoVeiculoId",
                        column: x => x.TipoVeiculoId,
                        principalTable: "TipoVeiculo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Veiculo_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemReservaId = table.Column<int>(type: "integer", nullable: false),
                    ItemReservaTermoAceiteId = table.Column<int>(type: "integer", nullable: true),
                    DataReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFinalReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Aprovada = table.Column<bool>(type: "boolean", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MotivoReprovacao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_AspNetUsers_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_ItemReservaTermoAceite_ItemReservaTermoAceiteId",
                        column: x => x.ItemReservaTermoAceiteId,
                        principalTable: "ItemReservaTermoAceite",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reserva_ItemReserva_ItemReservaId",
                        column: x => x.ItemReservaId,
                        principalTable: "ItemReserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcaoVoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    EnqueteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcaoVoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcaoVoto_Enquete_EnqueteId",
                        column: x => x.EnqueteId,
                        principalTable: "Enquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vaga = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CondominioId = table.Column<int>(type: "integer", nullable: false),
                    VeiculoId = table.Column<int>(type: "integer", nullable: true),
                    UsuarioCadastroId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garagem_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Garagem_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioVoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnqueteId = table.Column<int>(type: "integer", nullable: false),
                    OpcaoVotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioVoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioVoto_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioVoto_Enquete_EnqueteId",
                        column: x => x.EnqueteId,
                        principalTable: "Enquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioVoto_OpcaoVoto_OpcaoVotoId",
                        column: x => x.OpcaoVotoId,
                        principalTable: "OpcaoVoto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnexoReuniao_ReuniaoId",
                table: "AnexoReuniao",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CNHTypeId",
                table: "AspNetUsers",
                column: "CNHTypeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aviso_CondominioId",
                table: "Aviso",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloco_CondominioId",
                table: "Bloco",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_CondominioArquivo_BlocoId",
                table: "CondominioArquivo",
                column: "BlocoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondominioArquivo_CondominioId",
                table: "CondominioArquivo",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_CondominioArquivo_TipoArquivoId",
                table: "CondominioArquivo",
                column: "TipoArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondominioArquivo_UnidadeId",
                table: "CondominioArquivo",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquete_ReuniaoId",
                table: "Enquete",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_EmpresaEntregaId",
                table: "Entrega",
                column: "EmpresaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_TipoEncomendaId",
                table: "Entrega",
                column: "TipoEncomendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_UnidadeId",
                table: "Entrega",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_UsuarioCadastroId",
                table: "Entrega",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_UsuarioMoradorId",
                table: "Entrega",
                column: "UsuarioMoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_UsuarioRetiradaId",
                table: "Entrega",
                column: "UsuarioRetiradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Garagem_CondominioId",
                table: "Garagem",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Garagem_VeiculoId",
                table: "Garagem",
                column: "VeiculoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CondominioId",
                table: "Ocorrencia",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoOcorrenciaId",
                table: "Ocorrencia",
                column: "TipoOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_UsuarioCadastroId",
                table: "Ocorrencia",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcaoVoto_EnqueteId",
                table: "OpcaoVoto",
                column: "EnqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_ReuniaoId",
                table: "Presenca",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioId",
                table: "Presenca",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ItemReservaId",
                table: "Reserva",
                column: "ItemReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ItemReservaTermoAceiteId",
                table: "Reserva",
                column: "ItemReservaTermoAceiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UsuarioCadastroId",
                table: "Reserva",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reuniao_CondominioId",
                table: "Reuniao",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reuniao_UsuarioId",
                table: "Reuniao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReuniaoArquivo_ReuniaoId",
                table: "ReuniaoArquivo",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_BlocoId",
                table: "Unidade",
                column: "BlocoId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_UsuarioMoradorId",
                table: "Unidade",
                column: "UsuarioMoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCondominio_CondominioId",
                table: "UsuarioCondominio",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCondominio_RoleId",
                table: "UsuarioCondominio",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCondominio_UsuarioId",
                table: "UsuarioCondominio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioServico_UsuarioId",
                table: "UsuarioServico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidade_TipoMoradorId",
                table: "UsuarioUnidade",
                column: "TipoMoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidade_UnidadeId",
                table: "UsuarioUnidade",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioUnidade_UsuarioId",
                table: "UsuarioUnidade",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVoto_EnqueteId",
                table: "UsuarioVoto",
                column: "EnqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVoto_OpcaoVotoId",
                table: "UsuarioVoto",
                column: "OpcaoVotoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVoto_UsuarioId",
                table: "UsuarioVoto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_CondominioId",
                table: "Veiculo",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_CorId",
                table: "Veiculo",
                column: "CorId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_TipoVeiculoId",
                table: "Veiculo",
                column: "TipoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_UnidadeId",
                table: "Veiculo",
                column: "UnidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexoReuniao");

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
                name: "Aviso");

            migrationBuilder.DropTable(
                name: "CondominioArquivo");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Garagem");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "ReuniaoArquivo");

            migrationBuilder.DropTable(
                name: "UsuarioCondominio");

            migrationBuilder.DropTable(
                name: "UsuarioServico");

            migrationBuilder.DropTable(
                name: "UsuarioUnidade");

            migrationBuilder.DropTable(
                name: "UsuarioVoto");

            migrationBuilder.DropTable(
                name: "TipoArquivo");

            migrationBuilder.DropTable(
                name: "EmpresaEntrega");

            migrationBuilder.DropTable(
                name: "TipoEncomenda");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "TipoOcorrencia");

            migrationBuilder.DropTable(
                name: "ItemReservaTermoAceite");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TipoMorador");

            migrationBuilder.DropTable(
                name: "OpcaoVoto");

            migrationBuilder.DropTable(
                name: "Cor");

            migrationBuilder.DropTable(
                name: "TipoVeiculo");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "ItemReserva");

            migrationBuilder.DropTable(
                name: "Enquete");

            migrationBuilder.DropTable(
                name: "Bloco");

            migrationBuilder.DropTable(
                name: "TipoItemReserva");

            migrationBuilder.DropTable(
                name: "Reuniao");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "CNHType");
        }
    }
}
