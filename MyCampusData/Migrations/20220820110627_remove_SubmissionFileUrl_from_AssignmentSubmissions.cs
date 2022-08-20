using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCampusData.Migrations
{
    public partial class remove_SubmissionFileUrl_from_AssignmentSubmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionFileUrl",
                table: "ClassAssignmentSubmissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmissionFileUrl",
                table: "ClassAssignmentSubmissions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
