using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNAAnalysis.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGramsToMealSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NutritionProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NutritionProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NutritionProfiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NutritionPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NutritionPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NutritionPlans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MealSuggestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Grams",
                table: "MealSuggestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MealSuggestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MealSuggestions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NutritionProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NutritionProfiles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NutritionProfiles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NutritionPlans");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NutritionPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NutritionPlans");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MealSuggestions");

            migrationBuilder.DropColumn(
                name: "Grams",
                table: "MealSuggestions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MealSuggestions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MealSuggestions");
        }
    }
}
