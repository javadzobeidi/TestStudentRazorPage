using Microsoft.EntityFrameworkCore.Migrations;

namespace DataClassStudent.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentName",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentName",
                table: "Students",
                column: "StudentName",
                unique: true,
                filter: "[StudentName] IS NOT NULL");
        }
    }
}
