using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendOncologia.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DescricaoProtocolo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescricaoProtocolo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicacaoPreQuimio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicacaoPreQuimio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreQuimio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreQuimio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quimio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quimio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Permissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViaDeAdministracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaDeAdministracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicacaoPreQuimioDetalhe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codPreQuimio = table.Column<int>(name: "cod_PreQuimio", type: "INT", nullable: false),
                    codMedicacao = table.Column<int>(name: "cod_Medicacao", type: "INT", nullable: false),
                    codQuimio = table.Column<int>(name: "cod_Quimio", type: "INT", nullable: false),
                    codViaDeAdministracao = table.Column<int>(name: "cod_ViaDeAdministracao", type: "INT", nullable: false),
                    nomeUsuario = table.Column<string>(name: "nome_Usuario", type: "VARCHAR(50)", nullable: false),
                    quantidade = table.Column<int>(type: "INT", nullable: false),
                    unidadeQuantidade = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    diluicao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    tempoDeInfusao = table.Column<int>(type: "INT", nullable: false),
                    unidadeTempoDeInfusao = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicacaoPreQuimioDetalhe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicacaoPreQuimioDetalhe_MedicacaoPreQuimio_cod_Medicacao",
                        column: x => x.codMedicacao,
                        principalTable: "MedicacaoPreQuimio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicacaoPreQuimioDetalhe_PreQuimio_cod_PreQuimio",
                        column: x => x.codPreQuimio,
                        principalTable: "PreQuimio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicacaoPreQuimioDetalhe_Quimio_cod_Quimio",
                        column: x => x.codQuimio,
                        principalTable: "Quimio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicacaoPreQuimioDetalhe_ViaDeAdministracao_cod_ViaDeAdministracao",
                        column: x => x.codViaDeAdministracao,
                        principalTable: "ViaDeAdministracao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Protocolos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codDescricaoProtocolo = table.Column<int>(name: "cod_DescricaoProtocolo", type: "INT", nullable: false),
                    codMedicacao = table.Column<int>(name: "cod_Medicacao", type: "INT", nullable: false),
                    codPreQuimio = table.Column<int>(name: "cod_PreQuimio", type: "INT", nullable: false),
                    codViaDeAdministracao = table.Column<int>(name: "cod_ViaDeAdministracao", type: "INT", nullable: false),
                    nomeUsuario = table.Column<string>(name: "nome_Usuario", type: "VARCHAR(50)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false),
                    dose = table.Column<int>(type: "INT", nullable: false),
                    unidadeDose = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    diluicao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    tempoDeInfusao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    unidadeTempoDeInfusao = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocolos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protocolos_DescricaoProtocolo_cod_DescricaoProtocolo",
                        column: x => x.codDescricaoProtocolo,
                        principalTable: "DescricaoProtocolo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protocolos_Medicacao_cod_Medicacao",
                        column: x => x.codMedicacao,
                        principalTable: "Medicacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protocolos_PreQuimio_cod_PreQuimio",
                        column: x => x.codPreQuimio,
                        principalTable: "PreQuimio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protocolos_ViaDeAdministracao_cod_ViaDeAdministracao",
                        column: x => x.codViaDeAdministracao,
                        principalTable: "ViaDeAdministracao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicacaoPreQuimioDetalhe_cod_Medicacao",
                table: "MedicacaoPreQuimioDetalhe",
                column: "cod_Medicacao");

            migrationBuilder.CreateIndex(
                name: "IX_MedicacaoPreQuimioDetalhe_cod_PreQuimio",
                table: "MedicacaoPreQuimioDetalhe",
                column: "cod_PreQuimio");

            migrationBuilder.CreateIndex(
                name: "IX_MedicacaoPreQuimioDetalhe_cod_Quimio",
                table: "MedicacaoPreQuimioDetalhe",
                column: "cod_Quimio");

            migrationBuilder.CreateIndex(
                name: "IX_MedicacaoPreQuimioDetalhe_cod_ViaDeAdministracao",
                table: "MedicacaoPreQuimioDetalhe",
                column: "cod_ViaDeAdministracao");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_DescricaoProtocolo",
                table: "Protocolos",
                column: "cod_DescricaoProtocolo");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_Medicacao",
                table: "Protocolos",
                column: "cod_Medicacao");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_PreQuimio",
                table: "Protocolos",
                column: "cod_PreQuimio");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_ViaDeAdministracao",
                table: "Protocolos",
                column: "cod_ViaDeAdministracao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicacaoPreQuimioDetalhe");

            migrationBuilder.DropTable(
                name: "Protocolos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "MedicacaoPreQuimio");

            migrationBuilder.DropTable(
                name: "Quimio");

            migrationBuilder.DropTable(
                name: "DescricaoProtocolo");

            migrationBuilder.DropTable(
                name: "Medicacao");

            migrationBuilder.DropTable(
                name: "PreQuimio");

            migrationBuilder.DropTable(
                name: "ViaDeAdministracao");
        }
    }
}
