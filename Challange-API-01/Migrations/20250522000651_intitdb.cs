using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challange_API_01.Migrations
{
    /// <inheritdoc />
    public partial class intitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_mtt_estacao",
                columns: table => new
                {
                    IdEstacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmEstacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DsLocalizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NrCapacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DsStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DtUltimaAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DsResponsavel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mtt_estacao", x => x.IdEstacao);
                });

            migrationBuilder.CreateTable(
                name: "tb_mtt_historico_moto",
                columns: table => new
                {
                    IdHistorico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdMoto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TpAcao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DtAcao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mtt_historico_moto", x => x.IdHistorico);
                });

            migrationBuilder.CreateTable(
                name: "tb_mtt_moto",
                columns: table => new
                {
                    IdMoto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsPlaca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NmModelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DsCor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NrAno = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DsStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdEstacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DsVaga = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mtt_moto", x => x.IdMoto);
                });

            migrationBuilder.CreateTable(
                name: "tb_mtt_usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DsEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DsSenha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TpUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mtt_usuario", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_mtt_estacao");

            migrationBuilder.DropTable(
                name: "tb_mtt_historico_moto");

            migrationBuilder.DropTable(
                name: "tb_mtt_moto");

            migrationBuilder.DropTable(
                name: "tb_mtt_usuario");
        }
    }
}
