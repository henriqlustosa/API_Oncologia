using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendOncologia.Migrations
{
    /// <inheritdoc />
    public partial class atualizadotabelausuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreQuimio_Usuarios_cod_Usuario",
                table: "PreQuimio");

            migrationBuilder.DropForeignKey(
                name: "FK_PreQuimio_ViaDeAdministracao_cod_Usuario",
                table: "PreQuimio");

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacao", x => x.Id);
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
                    codUsuario = table.Column<int>(name: "cod_Usuario", type: "INT", nullable: false),
                    medicacaoId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Protocolos_Medicacao_medicacaoId",
                        column: x => x.medicacaoId,
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
                        name: "FK_Protocolos_Usuarios_cod_Usuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Protocolos_ViaDeAdministracao_cod_ViaDeAdministracao",
                        column: x => x.codViaDeAdministracao,
                        principalTable: "ViaDeAdministracao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_DescricaoProtocolo",
                table: "Protocolos",
                column: "cod_DescricaoProtocolo");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_PreQuimio",
                table: "Protocolos",
                column: "cod_PreQuimio");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_Usuario",
                table: "Protocolos",
                column: "cod_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_cod_ViaDeAdministracao",
                table: "Protocolos",
                column: "cod_ViaDeAdministracao");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_medicacaoId",
                table: "Protocolos",
                column: "medicacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreQuimio_Usuarios_cod_Usuario",
                table: "PreQuimio",
                column: "cod_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PreQuimio_ViaDeAdministracao_cod_Usuario",
                table: "PreQuimio",
                column: "cod_Usuario",
                principalTable: "ViaDeAdministracao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreQuimio_Usuarios_cod_Usuario",
                table: "PreQuimio");

            migrationBuilder.DropForeignKey(
                name: "FK_PreQuimio_ViaDeAdministracao_cod_Usuario",
                table: "PreQuimio");

            migrationBuilder.DropTable(
                name: "Protocolos");

            migrationBuilder.DropTable(
                name: "DescricaoProtocolo");

            migrationBuilder.DropTable(
                name: "Medicacao");

            migrationBuilder.AddForeignKey(
                name: "FK_PreQuimio_Usuarios_cod_Usuario",
                table: "PreQuimio",
                column: "cod_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreQuimio_ViaDeAdministracao_cod_Usuario",
                table: "PreQuimio",
                column: "cod_Usuario",
                principalTable: "ViaDeAdministracao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
