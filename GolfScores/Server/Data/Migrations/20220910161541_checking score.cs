using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfScores.Server.Data.Migrations
{
    public partial class checkingscore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NewScore",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Golfers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CourseId",
                table: "Scores",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GolferId",
                table: "Scores",
                column: "GolferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Courses_CourseId",
                table: "Scores",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Golfers_GolferId",
                table: "Scores",
                column: "GolferId",
                principalTable: "Golfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Courses_CourseId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Golfers_GolferId",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_CourseId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_GolferId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Scores");

            migrationBuilder.AlterColumn<int>(
                name: "NewScore",
                table: "Scores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Golfers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
