using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WoMakersCode.ToDoList.Infra.Migrations
{
    public partial class MigracaoDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tasklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taskdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(300)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Executado = table.Column<int>(type: "INT", nullable: false),
                    IdTaskList = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskdetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskdetails_tasklists_IdTaskList",
                        column: x => x.IdTaskList,
                        principalTable: "tasklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alarms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdTaskDetail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alarms_taskdetails_IdTaskDetail",
                        column: x => x.IdTaskDetail,
                        principalTable: "taskdetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alarms_IdTaskDetail",
                table: "alarms",
                column: "IdTaskDetail");

            migrationBuilder.CreateIndex(
                name: "IX_taskdetails_IdTaskList",
                table: "taskdetails",
                column: "IdTaskList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alarms");

            migrationBuilder.DropTable(
                name: "taskdetails");

            migrationBuilder.DropTable(
                name: "tasklists");
        }
    }
}
