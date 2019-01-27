using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class upgradedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    ConferenceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameConference = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.ConferenceID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameStore = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "AuthorConference",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    ConferenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorConference", x => new { x.AuthorId, x.ConferenceId });
                    table.ForeignKey(
                        name: "FK_AuthorConference_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorConference_Conference_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conference",
                        principalColumn: "ConferenceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookStore",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStore", x => new { x.BookId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_BookStore_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorConference_ConferenceId",
                table: "AuthorConference",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStore_StoreId",
                table: "BookStore",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorConference");

            migrationBuilder.DropTable(
                name: "BookStore");

            migrationBuilder.DropTable(
                name: "Conference");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
