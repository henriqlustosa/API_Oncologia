using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendOncologia.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoprequimio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TipoPreQuimio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPreQuimio", x => x.Id);
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
                name: "PreQuimio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codTipoPreQuimio = table.Column<int>(name: "cod_TipoPreQuimio", type: "INT", nullable: false),
                    codMedicacao = table.Column<int>(name: "cod_Medicacao", type: "INT", nullable: false),
                    codQuimio = table.Column<int>(name: "cod_Quimio", type: "INT", nullable: false),
                    codViaDeAdministracao = table.Column<int>(name: "cod_ViaDeAdministracao", type: "INT", nullable: false),
                    codUsuario = table.Column<int>(name: "cod_Usuario", type: "INT", nullable: false),
                    quantidade = table.Column<int>(type: "INT", nullable: false),
                    unidadeQuantidade = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    quimio = table.Column<int>(type: "int", nullable: false),
                    diluicao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    tempoDeInfusao = table.Column<int>(type: "INT", nullable: false),
                    unidadeTempoDeInfusao = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    status = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreQuimio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreQuimio_MedicacaoPreQuimio_cod_Medicacao",
                        column: x => x.codMedicacao,
                        principalTable: "MedicacaoPreQuimio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreQuimio_TipoPreQuimio_cod_TipoPreQuimio",
                        column: x => x.codTipoPreQuimio,
                        principalTable: "TipoPreQuimio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreQuimio_Usuarios_cod_Usuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreQuimio_ViaDeAdministracao_cod_Usuario",
                        column: x => x.codUsuario,
                        principalTable: "ViaDeAdministracao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreQuimio_cod_Medicacao",
                table: "PreQuimio",
                column: "cod_Medicacao");

            migrationBuilder.CreateIndex(
                name: "IX_PreQuimio_cod_TipoPreQuimio",
                table: "PreQuimio",
                column: "cod_TipoPreQuimio");

            migrationBuilder.CreateIndex(
                name: "IX_PreQuimio_cod_Usuario",
                table: "PreQuimio",
                column: "cod_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreQuimio");

            migrationBuilder.DropTable(
                name: "MedicacaoPreQuimio");

            migrationBuilder.DropTable(
                name: "TipoPreQuimio");

            migrationBuilder.DropTable(
                name: "ViaDeAdministracao");
        }
    }
}
