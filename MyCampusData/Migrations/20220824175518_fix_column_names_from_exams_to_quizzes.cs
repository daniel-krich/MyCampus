using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCampusData.Migrations
{
    public partial class fix_column_names_from_exams_to_quizzes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuizQuestions_ClassQuizzes_ExamId",
                table: "ClassQuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuizSubmissions_ClassQuizzes_ExamId",
                table: "ClassQuizSubmissions");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "ClassQuizSubmissions",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassQuizSubmissions_ExamId",
                table: "ClassQuizSubmissions",
                newName: "IX_ClassQuizSubmissions_QuizId");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "ClassQuizQuestions",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassQuizQuestions_ExamId",
                table: "ClassQuizQuestions",
                newName: "IX_ClassQuizQuestions_QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuizQuestions_ClassQuizzes_QuizId",
                table: "ClassQuizQuestions",
                column: "QuizId",
                principalTable: "ClassQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuizSubmissions_ClassQuizzes_QuizId",
                table: "ClassQuizSubmissions",
                column: "QuizId",
                principalTable: "ClassQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuizQuestions_ClassQuizzes_QuizId",
                table: "ClassQuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassQuizSubmissions_ClassQuizzes_QuizId",
                table: "ClassQuizSubmissions");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "ClassQuizSubmissions",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassQuizSubmissions_QuizId",
                table: "ClassQuizSubmissions",
                newName: "IX_ClassQuizSubmissions_ExamId");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "ClassQuizQuestions",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassQuizQuestions_QuizId",
                table: "ClassQuizQuestions",
                newName: "IX_ClassQuizQuestions_ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuizQuestions_ClassQuizzes_ExamId",
                table: "ClassQuizQuestions",
                column: "ExamId",
                principalTable: "ClassQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassQuizSubmissions_ClassQuizzes_ExamId",
                table: "ClassQuizSubmissions",
                column: "ExamId",
                principalTable: "ClassQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
