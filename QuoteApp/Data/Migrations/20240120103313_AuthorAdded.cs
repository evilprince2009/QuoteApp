using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirtyQuotes");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Quote");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Quote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quote_AuthorId",
                table: "Quote",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_Author_AuthorId",
                table: "Quote",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_Author_AuthorId",
                table: "Quote");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Quote_AuthorId",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Quote");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Quote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DirtyQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirtyQuotes", x => x.Id);
                });
        }
    }
}
