using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Application.Migrations
{
    /// <inheritdoc />
    public partial class GenreSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("03d560f4-ba2f-490a-8084-adaaa031246a"), "Horror", "Horror" },
                    { new Guid("22f205fa-b4b0-47d5-9387-b9c9a158eb67"), "Science Fiction", "Science Fiction" },
                    { new Guid("5ea82b38-4cc7-4ae1-a4eb-9a85f23ea033"), "Thriller", "Thriller" },
                    { new Guid("633aba6f-d3c0-46ad-aa26-4a753747eb9f"), "Fantasy", "Fantasy" },
                    { new Guid("72b914ea-a9d7-43c6-8a20-7c12dd6658f2"), "Drama", "Drama" },
                    { new Guid("a1b852e7-5a34-43eb-980f-0875fb1d58e9"), "Adventure", "Adventure" },
                    { new Guid("d8e034a2-f63e-4b9a-98b4-9cbd7ded53f8"), "Romance", "Romance" },
                    { new Guid("e910a588-612c-42fd-ae0c-555f672eb3bf"), "Action", "Action" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("03d560f4-ba2f-490a-8084-adaaa031246a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("22f205fa-b4b0-47d5-9387-b9c9a158eb67"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5ea82b38-4cc7-4ae1-a4eb-9a85f23ea033"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("633aba6f-d3c0-46ad-aa26-4a753747eb9f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("72b914ea-a9d7-43c6-8a20-7c12dd6658f2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a1b852e7-5a34-43eb-980f-0875fb1d58e9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d8e034a2-f63e-4b9a-98b4-9cbd7ded53f8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e910a588-612c-42fd-ae0c-555f672eb3bf"));
        }
    }
}
