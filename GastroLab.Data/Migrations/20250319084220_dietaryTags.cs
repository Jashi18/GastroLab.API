using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GastroLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class dietaryTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NutritionalInfoId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DietaryTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false),
                    ServingSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionalInfos_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietaryTagRecipe",
                columns: table => new
                {
                    DietaryTagsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryTagRecipe", x => new { x.DietaryTagsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_DietaryTags_DietaryTagsId",
                        column: x => x.DietaryTagsId,
                        principalTable: "DietaryTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietaryTagRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietaryTagRecipe_RecipesId",
                table: "DietaryTagRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalInfos_RecipeId",
                table: "NutritionalInfos",
                column: "RecipeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietaryTagRecipe");

            migrationBuilder.DropTable(
                name: "NutritionalInfos");

            migrationBuilder.DropTable(
                name: "DietaryTags");

            migrationBuilder.DropColumn(
                name: "NutritionalInfoId",
                table: "Recipes");
        }
    }
}
