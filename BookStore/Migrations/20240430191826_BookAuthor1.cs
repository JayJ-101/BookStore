using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class BookAuthor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[,]
                {
                    { 1, 24 },
                    { 2, 4 },
                    { 2, 9 },
                    { 3, 22 },
                    { 4, 12 },
                    { 4, 18 },
                    { 4, 28 },
                    { 5, 14 },
                    { 6, 26 },
                    { 7, 3 },
                    { 7, 17 },
                    { 8, 6 },
                    { 9, 15 },
                    { 10, 25 },
                    { 11, 19 },
                    { 12, 7 },
                    { 13, 16 },
                    { 14, 23 },
                    { 15, 11 },
                    { 16, 8 },
                    { 17, 21 },
                    { 18, 1 },
                    { 19, 5 },
                    { 20, 2 },
                    { 20, 10 },
                    { 21, 13 },
                    { 22, 20 },
                    { 23, 27 },
                    { 25, 29 },
                    { 26, 28 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 4, 28 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 6, 26 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 7, 17 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 10, 25 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 11, 19 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 13, 16 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 14, 23 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 15, 11 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 16, 8 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 17, 21 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 20, 10 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 21, 13 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 22, 20 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 23, 27 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 25, 29 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { 26, 28 });
        }
    }
}
