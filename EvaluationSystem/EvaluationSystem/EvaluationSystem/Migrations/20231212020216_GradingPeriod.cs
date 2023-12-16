using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class GradingPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradingPeriod",
                columns: table => new
                {
                    GradingPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradingPeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingPeriod", x => x.GradingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    TermId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.TermId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradingPeriod");

            migrationBuilder.DropTable(
                name: "Term");
        }
    }
}
