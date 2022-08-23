using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCampusData.Migrations
{
    public partial class add_exam_related_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndSubmissionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassExams_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassExamQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassExamQuestions_ClassExams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "ClassExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassExamSubmissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExamSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassExamSubmissions_ClassExams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "ClassExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassExamSubmissions_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassExamAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsRight = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExamAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassExamAnswers_ClassExamQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ClassExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassExamSubmissionAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamSubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExamSubmissionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassExamSubmissionAnswers_ClassExamAnswers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "ClassExamAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassExamSubmissionAnswers_ClassExamSubmissions_ExamSubmissionId",
                        column: x => x.ExamSubmissionId,
                        principalTable: "ClassExamSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassExamAnswers_QuestionId",
                table: "ClassExamAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExamQuestions_ExamId",
                table: "ClassExamQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_ClassId",
                table: "ClassExams",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExamSubmissionAnswers_AnswerId",
                table: "ClassExamSubmissionAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExamSubmissionAnswers_ExamSubmissionId",
                table: "ClassExamSubmissionAnswers",
                column: "ExamSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExamSubmissions_ExamId",
                table: "ClassExamSubmissions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExamSubmissions_StudentId",
                table: "ClassExamSubmissions",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassExamSubmissionAnswers");

            migrationBuilder.DropTable(
                name: "ClassExamAnswers");

            migrationBuilder.DropTable(
                name: "ClassExamSubmissions");

            migrationBuilder.DropTable(
                name: "ClassExamQuestions");

            migrationBuilder.DropTable(
                name: "ClassExams");
        }
    }
}
