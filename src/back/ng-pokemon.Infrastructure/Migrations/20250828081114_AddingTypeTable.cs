using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ng_pokemon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Types",
                table: "Pokemon");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemon",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PokemonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonPokemonType",
                columns: table => new
                {
                    PokemonTypesId = table.Column<int>(type: "int", nullable: false),
                    PokemonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPokemonType", x => new { x.PokemonTypesId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_PokemonPokemonType_PokemonType_PokemonTypesId",
                        column: x => x.PokemonTypesId,
                        principalTable: "PokemonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPokemonType_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PokemonType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steel" },
                    { 2, "Fighting" },
                    { 3, "Dragon" },
                    { 4, "Water" },
                    { 5, "Electric" },
                    { 6, "Fairy" },
                    { 7, "Fire" },
                    { 8, "Ice" },
                    { 9, "Bug" },
                    { 10, "Normal" },
                    { 11, "Grass" },
                    { 12, "Poison" },
                    { 13, "Psychic" },
                    { 14, "Rock" },
                    { 15, "Ground" },
                    { 16, "Ghost" },
                    { 17, "Dark" },
                    { 18, "Flying" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemonType_PokemonsId",
                table: "PokemonPokemonType",
                column: "PokemonsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonPokemonType");

            migrationBuilder.DropTable(
                name: "PokemonType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Types",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
