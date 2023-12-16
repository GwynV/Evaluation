using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class Peer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeerEvaluation",
                columns: table => new
                {
                    PeerEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    EvaluationDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerEvaluation", x => x.PeerEvaluationId);
                    table.ForeignKey(
                        name: "FK_PeerEvaluation_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeerEvaluation_EvaluationDetails_EvaluationDetailsId",
                        column: x => x.EvaluationDetailsId,
                        principalTable: "EvaluationDetails",
                        principalColumn: "EvaluationDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeerEvaluation_EvaluationDetailsId",
                table: "PeerEvaluation",
                column: "EvaluationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerEvaluation_EvaluationId",
                table: "PeerEvaluation",
                column: "EvaluationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeerEvaluation");
        }
    }
}
