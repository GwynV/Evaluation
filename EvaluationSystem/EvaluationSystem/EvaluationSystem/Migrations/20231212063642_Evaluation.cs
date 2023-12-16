using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class Evaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    GradingPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluation_GradingPeriod_GradingPeriodId",
                        column: x => x.GradingPeriodId,
                        principalTable: "GradingPeriod",
                        principalColumn: "GradingPeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_GradingPeriodId",
                table: "Evaluation",
                column: "GradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_TermId",
                table: "Evaluation",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_UserId",
                table: "Evaluation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");
        }
    }
}
