using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCampusData.Migrations
{
    public partial class add_bundles_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignmentSource",
                table: "ClassAssignments",
                newName: "AssignmentText");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignmentSubmissionBundleId",
                table: "ClassAssignmentSubmissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignmentBundleId",
                table: "ClassAssignments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BundleSize = table.Column<long>(type: "bigint", nullable: false),
                    BundleFiles = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignmentSubmissions_AssignmentSubmissionBundleId",
                table: "ClassAssignmentSubmissions",
                column: "AssignmentSubmissionBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignments_AssignmentBundleId",
                table: "ClassAssignments",
                column: "AssignmentBundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignments_Bundles_AssignmentBundleId",
                table: "ClassAssignments",
                column: "AssignmentBundleId",
                principalTable: "Bundles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignmentSubmissions_Bundles_AssignmentSubmissionBundleId",
                table: "ClassAssignmentSubmissions",
                column: "AssignmentSubmissionBundleId",
                principalTable: "Bundles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignments_Bundles_AssignmentBundleId",
                table: "ClassAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignmentSubmissions_Bundles_AssignmentSubmissionBundleId",
                table: "ClassAssignmentSubmissions");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropIndex(
                name: "IX_ClassAssignmentSubmissions_AssignmentSubmissionBundleId",
                table: "ClassAssignmentSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_ClassAssignments_AssignmentBundleId",
                table: "ClassAssignments");

            migrationBuilder.DropColumn(
                name: "AssignmentSubmissionBundleId",
                table: "ClassAssignmentSubmissions");

            migrationBuilder.DropColumn(
                name: "AssignmentBundleId",
                table: "ClassAssignments");

            migrationBuilder.RenameColumn(
                name: "AssignmentText",
                table: "ClassAssignments",
                newName: "AssignmentSource");
        }
    }
}
