using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class Head : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadEvaluation",
                columns: table => new
                {
                    HeadEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    EvaluationDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadEvaluation", x => x.HeadEvaluationId);
                    table.ForeignKey(
                        name: "FK_HeadEvaluation_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadEvaluation_EvaluationDetails_EvaluationDetailsId",
                        column: x => x.EvaluationDetailsId,
                        principalTable: "EvaluationDetails",
                        principalColumn: "EvaluationDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeadEvaluation_EvaluationDetailsId",
                table: "HeadEvaluation",
                column: "EvaluationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadEvaluation_EvaluationId",
                table: "HeadEvaluation",
                column: "EvaluationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadEvaluation");
        }
    }
}
