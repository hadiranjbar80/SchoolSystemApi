using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolCode);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ParentPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CommuteService = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
