using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Application.Migrations
{
    /// <inheritdoc />
    public partial class GenreRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("05c69db2-4825-4591-8478-feba4d850d87"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("27128d98-fdff-4790-9d2a-4b73f6cde732"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("472f8a03-ad48-467b-9051-fad5c8bcbf96"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6140768d-83c2-46c1-bc5c-8e6b4559d14b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("79fb5cb4-279c-49ea-b5fd-a6497b5b5733"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("97bc81e1-bec7-4ba1-9e8e-53f2cc41d356"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9c5e6724-a6c2-41cb-acd5-52cdb5cd125e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c7e1e772-817a-4063-817a-9b93047fdfcc"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Genres",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("05c69db2-4825-4591-8478-feba4d850d87"), "Drama", "Drama" },
                    { new Guid("27128d98-fdff-4790-9d2a-4b73f6cde732"), "Horror", "Horror" },
                    { new Guid("472f8a03-ad48-467b-9051-fad5c8bcbf96"), "Romance", "Romance" },
                    { new Guid("6140768d-83c2-46c1-bc5c-8e6b4559d14b"), "Thriller", "Thriller" },
                    { new Guid("79fb5cb4-279c-49ea-b5fd-a6497b5b5733"), "Adventure", "Adventure" },
                    { new Guid("97bc81e1-bec7-4ba1-9e8e-53f2cc41d356"), "Action", "Action" },
                    { new Guid("9c5e6724-a6c2-41cb-acd5-52cdb5cd125e"), "Science Fiction", "Science Fiction" },
                    { new Guid("c7e1e772-817a-4063-817a-9b93047fdfcc"), "Fantasy", "Fantasy" }
                });
        }
    }
}
