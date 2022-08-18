using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCampusData.Migrations
{
    public partial class add_LecturerNotes_LecturerEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Evaluation",
                table: "ClassAssignmentSubmissions",
                newName: "LecturerEvaluation");

            migrationBuilder.AddColumn<string>(
                name: "LecturerNotes",
                table: "ClassAssignmentSubmissions",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LecturerNotes",
                table: "ClassAssignmentSubmissions");

            migrationBuilder.RenameColumn(
                name: "LecturerEvaluation",
                table: "ClassAssignmentSubmissions",
                newName: "Evaluation");
        }
    }
}
