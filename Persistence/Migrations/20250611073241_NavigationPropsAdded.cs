using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NavigationPropsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolCode",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolCode",
                table: "Students",
                column: "SchoolCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolCode",
                table: "Students",
                column: "SchoolCode",
                principalTable: "Schools",
                principalColumn: "SchoolCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolCode",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolCode",
                table: "Students");
        }
    }
}
