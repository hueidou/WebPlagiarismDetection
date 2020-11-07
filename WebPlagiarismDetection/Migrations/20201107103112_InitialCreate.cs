using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPlagiarismDetection.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    SentenceId = table.Column<Guid>(nullable: false),
                    WpdId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    No = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.SentenceId);
                });

            migrationBuilder.CreateTable(
                name: "SentenceSearchs",
                columns: table => new
                {
                    SentenceSearchId = table.Column<Guid>(nullable: false),
                    SentenceId = table.Column<Guid>(nullable: false),
                    SearchEngine = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    No = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceSearchs", x => x.SentenceSearchId);
                });

            migrationBuilder.CreateTable(
                name: "Wpds",
                columns: table => new
                {
                    WpdId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    File = table.Column<byte[]>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DetectBeginTime = table.Column<DateTime>(nullable: false),
                    DetectEndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpds", x => x.WpdId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "SentenceSearchs");

            migrationBuilder.DropTable(
                name: "Wpds");
        }
    }
}
