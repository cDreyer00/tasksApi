using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tasksApi.Migrations
{
    /// <inheritdoc />
    public partial class TaskModelClassChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "done",
                table: "Tasks",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tasks",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Tasks",
                newName: "done");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "id");
        }
    }
}
