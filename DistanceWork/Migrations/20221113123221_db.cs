using Microsoft.EntityFrameworkCore.Migrations;

namespace DistanceWork.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    TelNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    filePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Master = table.Column<int>(nullable: false),
                    Worker = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    TaskFile = table.Column<string>(nullable: true),
                    CompleteFile = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DateBegin = table.Column<string>(nullable: true),
                    Deadline = table.Column<string>(nullable: true),
                    DateComplite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
