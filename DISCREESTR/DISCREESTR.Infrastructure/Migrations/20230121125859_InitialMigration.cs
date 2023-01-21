using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DISCREESTR.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otcestvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studplans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KursNumb = table.Column<int>(type: "int", nullable: false),
                    FormControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clocks = table.Column<int>(type: "int", nullable: false),
                    Semestr = table.Column<int>(type: "int", nullable: false),
                    PrepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studplans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studplans_Preps_PrepId",
                        column: x => x.PrepId,
                        principalTable: "Preps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studplans_PrepId",
                table: "Studplans",
                column: "PrepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studplans");

            migrationBuilder.DropTable(
                name: "Preps");
        }
    }
}
