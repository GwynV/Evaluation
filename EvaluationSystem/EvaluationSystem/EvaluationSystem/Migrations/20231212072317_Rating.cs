using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationCategory",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCategory", x => x.EvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationRating",
                columns: table => new
                {
                    EvaluationRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationRatingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EvaluationScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationRating", x => x.EvaluationRatingId);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationDetails",
                columns: table => new
                {
                    EvaluationDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationRatingId = table.Column<int>(type: "int", nullable: false),
                    EvaluationCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationDetails", x => x.EvaluationDetailsId);
                    table.ForeignKey(
                        name: "FK_EvaluationDetails_EvaluationCategory_EvaluationCategoryId",
                        column: x => x.EvaluationCategoryId,
                        principalTable: "EvaluationCategory",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationDetails_EvaluationRating_EvaluationRatingId",
                        column: x => x.EvaluationRatingId,
                        principalTable: "EvaluationRating",
                        principalColumn: "EvaluationRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_EvaluationCategoryId",
                table: "EvaluationDetails",
                column: "EvaluationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_EvaluationRatingId",
                table: "EvaluationDetails",
                column: "EvaluationRatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationDetails");

            migrationBuilder.DropTable(
                name: "EvaluationCategory");

            migrationBuilder.DropTable(
                name: "EvaluationRating");
        }
    }
}
