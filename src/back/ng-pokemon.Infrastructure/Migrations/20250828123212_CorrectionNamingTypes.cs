using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ng_pokemon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionNamingTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonPokemonType_PokemonType_PokemonTypesId",
                table: "PokemonPokemonType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonType",
                table: "PokemonType");

            migrationBuilder.RenameTable(
                name: "PokemonType",
                newName: "PokemonTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonTypes",
                table: "PokemonTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonPokemonType_PokemonTypes_PokemonTypesId",
                table: "PokemonPokemonType",
                column: "PokemonTypesId",
                principalTable: "PokemonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonPokemonType_PokemonTypes_PokemonTypesId",
                table: "PokemonPokemonType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonTypes",
                table: "PokemonTypes");

            migrationBuilder.RenameTable(
                name: "PokemonTypes",
                newName: "PokemonType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonType",
                table: "PokemonType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonPokemonType_PokemonType_PokemonTypesId",
                table: "PokemonPokemonType",
                column: "PokemonTypesId",
                principalTable: "PokemonType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
