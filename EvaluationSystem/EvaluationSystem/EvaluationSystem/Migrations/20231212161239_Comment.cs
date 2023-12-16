using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentEvalId",
                table: "EvaluationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "EvaluationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommentEval",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentedById = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEval", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentEval_Evaluation_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluation",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_CommentEvalId",
                table: "EvaluationDetails",
                column: "CommentEvalId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentEval_EvaluationId",
                table: "CommentEval",
                column: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationDetails_CommentEval_CommentEvalId",
                table: "EvaluationDetails",
                column: "CommentEvalId",
                principalTable: "CommentEval",
                principalColumn: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationDetails_CommentEval_CommentEvalId",
                table: "EvaluationDetails");

            migrationBuilder.DropTable(
                name: "CommentEval");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationDetails_CommentEvalId",
                table: "EvaluationDetails");

            migrationBuilder.DropColumn(
                name: "CommentEvalId",
                table: "EvaluationDetails");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "EvaluationDetails");
        }
    }
}
