using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItProjectManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectChangeLog_ProjectId",
                table: "ProjectChangeLog");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "ProjectChangeLog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeLog_ProjectId",
                table: "ProjectChangeLog",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeLog_ProjectId1",
                table: "ProjectChangeLog",
                column: "ProjectId1",
                unique: true,
                filter: "[ProjectId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectChangeLog_Projects_ProjectId1",
                table: "ProjectChangeLog",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectChangeLog_Projects_ProjectId1",
                table: "ProjectChangeLog");

            migrationBuilder.DropIndex(
                name: "IX_ProjectChangeLog_ProjectId",
                table: "ProjectChangeLog");

            migrationBuilder.DropIndex(
                name: "IX_ProjectChangeLog_ProjectId1",
                table: "ProjectChangeLog");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "ProjectChangeLog");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectChangeLog_ProjectId",
                table: "ProjectChangeLog",
                column: "ProjectId",
                unique: true);
        }
    }
}
