using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItProjectManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDependencies",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    DependentOnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDependencies", x => new { x.TaskId, x.DependentOnId });
                    table.ForeignKey(
                        name: "FK_TaskDependencies_Tasks_DependentOnId",
                        column: x => x.DependentOnId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskDependencies_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDependencies_DependentOnId",
                table: "TaskDependencies",
                column: "DependentOnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDependencies");
        }
    }
}
