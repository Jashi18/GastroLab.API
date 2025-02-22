using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GastroLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class baseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Recipes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Recipes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Ingredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Ingredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Categories");
        }
    }
}
