using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationSystem.Migrations
{
    public partial class finaldb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationDetails_CommentEval_CommentEvalId",
                table: "EvaluationDetails");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationDetails_CommentEvalId",
                table: "EvaluationDetails");

            migrationBuilder.DropColumn(
                name: "CommentEvalId",
                table: "EvaluationDetails");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "EvaluationDetails",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EvaluationId",
                table: "EvaluationCategory",
                newName: "EvaluationCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationDetailsId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluatedUserId",
                table: "EvaluationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluationId",
                table: "EvaluationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CommentEval",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_EvaluationDetailsId",
                table: "User",
                column: "EvaluationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionId",
                table: "User",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_EvaluatedUserId",
                table: "EvaluationDetails",
                column: "EvaluatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_EvaluationId",
                table: "EvaluationDetails",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_UserId",
                table: "EvaluationDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentEval_CommentedById",
                table: "CommentEval",
                column: "CommentedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommentEval_UserId",
                table: "CommentEval",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEval_User_CommentedById",
                table: "CommentEval",
                column: "CommentedById",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEval_User_UserId",
                table: "CommentEval",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationDetails_Evaluation_EvaluationId",
                table: "EvaluationDetails",
                column: "EvaluationId",
                principalTable: "Evaluation",
                principalColumn: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationDetails_User_EvaluatedUserId",
                table: "EvaluationDetails",
                column: "EvaluatedUserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationDetails_User_UserId",
                table: "EvaluationDetails",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_EvaluationDetails_EvaluationDetailsId",
                table: "User",
                column: "EvaluationDetailsId",
                principalTable: "EvaluationDetails",
                principalColumn: "EvaluationDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEval_User_CommentedById",
                table: "CommentEval");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentEval_User_UserId",
                table: "CommentEval");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationDetails_Evaluation_EvaluationId",
                table: "EvaluationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationDetails_User_EvaluatedUserId",
                table: "EvaluationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationDetails_User_UserId",
                table: "EvaluationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_User_EvaluationDetails_EvaluationDetailsId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EvaluationDetailsId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PositionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationDetails_EvaluatedUserId",
                table: "EvaluationDetails");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationDetails_EvaluationId",
                table: "EvaluationDetails");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationDetails_UserId",
                table: "EvaluationDetails");

            migrationBuilder.DropIndex(
                name: "IX_CommentEval_CommentedById",
                table: "CommentEval");

            migrationBuilder.DropIndex(
                name: "IX_CommentEval_UserId",
                table: "CommentEval");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EvaluationDetailsId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EvaluatedUserId",
                table: "EvaluationDetails");

            migrationBuilder.DropColumn(
                name: "EvaluationId",
                table: "EvaluationDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentEval");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EvaluationDetails",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "EvaluationCategoryId",
                table: "EvaluationCategory",
                newName: "EvaluationId");

            migrationBuilder.AddColumn<int>(
                name: "CommentEvalId",
                table: "EvaluationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationDetails_CommentEvalId",
                table: "EvaluationDetails",
                column: "CommentEvalId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PositionId",
                table: "Staff",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationDetails_CommentEval_CommentEvalId",
                table: "EvaluationDetails",
                column: "CommentEvalId",
                principalTable: "CommentEval",
                principalColumn: "CommentId");
        }
    }
}
